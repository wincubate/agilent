using Client.Contract;
using System;
using System.ServiceModel;

namespace ClientApp.Services
{
    class DuplexReagentClient :
        DuplexClientBase<IClientContract>, 
        IClientContract,
        IDisposable
    {
        public DuplexReagentClient(
            InstanceContext callbackInstance) : base(
                callbackInstance,
                new NetTcpBinding(),
                new EndpointAddress("net.tcp://localhost:9090/Clients/")
            )
        {
        }

        public void Connect()
        {
            Channel.Connect();
        }

        public void SetNote(int serial, string note)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            Channel.Disconnect();
        }
    }
}
