using Middleware;
using System;
using System.Threading;

namespace InstrumentApp
{
    class Program
    {
        static void Main()
        {
            ILogger logger = new ConsoleLogger($"Instruments");

            using (IWorkerThread<Instrument> workerThread1 = new InstrumentWorkerThread(logger),
                                             workerThread2 = new InstrumentWorkerThread(logger),
                                             workerThread3 = new InstrumentWorkerThread(logger),
                                             workerThread4 = new InstrumentWorkerThread(logger)
                )
            {
                logger.LogInfo("Starting instrument threads");
                Thread.Sleep(2000);

                workerThread1.Start(new Instrument("GF 176", TimeSpan.FromMilliseconds(200)));
                workerThread2.Start(new Instrument("8K 8260", TimeSpan.FromMilliseconds(300)));
                workerThread3.Start(new Instrument("RAMMS+1", TimeSpan.FromMilliseconds(500)));
                workerThread4.Start(new Instrument("CUL8R", TimeSpan.FromMilliseconds(200)));

                Console.ReadLine();

                logger.LogInfo("Shutting down...");
            }
        }
    }
}
