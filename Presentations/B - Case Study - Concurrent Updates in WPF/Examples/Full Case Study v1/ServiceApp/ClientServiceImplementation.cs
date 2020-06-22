using Client.Contract;
using System;
using System.ServiceModel;
using System.Threading;

namespace ServiceApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class ClientServiceImplementation : IClientContract
    {
        private readonly IServiceMediator _serviceMediator;

        public ClientServiceImplementation(IServiceMediator serviceMediator)
        {
            _serviceMediator = serviceMediator;
        }

        public void Connect()
        {
            IClientCallbackContract client = OperationContext.Current.GetCallbackChannel<IClientCallbackContract>();            
            _serviceMediator.OnClientConnected(client);

            //Thread.Sleep(1000);
        }

        public void Disconnect()
        {
            IClientCallbackContract client = OperationContext.Current.GetCallbackChannel<IClientCallbackContract>();
            _serviceMediator.OnClientDisconnected(client);
        }

        public void SetNote(int serial, string note)
        {
            throw new NotImplementedException();
        }
    }
}
