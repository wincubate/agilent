using Client.Contract;
using Instrument.Contract;
using Middleware;
using System;
using System.ServiceModel;

namespace ServiceApp
{
    class Program
    {
        static void Main()
        {
            ILogger logger = new ConsoleLogger("Service");
            IAsyncServiceMediator mediator = new ServiceMeditator(logger);

            Uri instrumentBaseAddress = new Uri("http://localhost:8080/Instruments/");
            Uri clientReagentBaseAddress = new Uri("net.tcp://localhost:9090/Clients/");
            
            var displayClientServiceImplementation = new ClientServiceImplementation(mediator);
            var instrumentServiceImplementation = new InstrumentServiceImplementation(mediator);

            using (
                ServiceHost displayClientHost = new ServiceHost(
                    displayClientServiceImplementation,
                    clientReagentBaseAddress
                ),
                instrumentHost = new ServiceHost(
                    instrumentServiceImplementation,
                    instrumentBaseAddress
                ))
            {
                // Client Reagent Host
                displayClientHost.AddServiceEndpoint(
                    typeof(IClientAsyncContract),
                    new NetTcpBinding(),
                    string.Empty
                );
                displayClientHost.Open();
                logger.LogInfo("Client Reagent host opened");

                // Instrument Host
                instrumentHost.AddServiceEndpoint(
                    typeof(IInstrumentAsyncContract),
                    new WSHttpBinding(),
                    string.Empty
                );
                instrumentHost.Open();
                logger.LogInfo("Instrument host opened");

                Console.ReadLine();
                logger.LogInfo("Closing hosts...");
            }
        }
    }
}