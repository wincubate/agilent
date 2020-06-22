using Client.Contract;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServiceApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class ClientServiceImplementation : IClientAsyncContract
    {
        private readonly IAsyncServiceMediator _serviceMediator;

        public ClientServiceImplementation(IAsyncServiceMediator serviceMediator)
        {
            _serviceMediator = serviceMediator;
        }

        public async Task ConnectAsync()
        {
            IClientAsyncCallbackContract client = OperationContext.Current.GetCallbackChannel<IClientAsyncCallbackContract>();            
            await _serviceMediator.OnClientConnectedAsync(client).ConfigureAwait(false);

            //Thread.Sleep(1000);
        }

        public async Task DisconnectAsync()
        {
            IClientAsyncCallbackContract client = OperationContext.Current.GetCallbackChannel<IClientAsyncCallbackContract>();
            await _serviceMediator.OnClientDisconnectedAsync(client).ConfigureAwait(false);
        }

        public Task SetNoteAsync(int serial, string note)
        {
            throw new NotImplementedException();
        }
    }
}
