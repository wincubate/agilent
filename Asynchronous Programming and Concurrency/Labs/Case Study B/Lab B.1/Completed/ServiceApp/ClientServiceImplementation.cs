using Client.Contract;
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

        public async Task SetNoteAsync(int serial, string note)
        {
            // Make sure we don't send update back to originating client in order to avoid reentrancy issues
            IClientAsyncCallbackContract client = OperationContext.Current.GetCallbackChannel<IClientAsyncCallbackContract>();
            await _serviceMediator.OnNoteUpdatedAsync(client, serial, note).ConfigureAwait(false);
        }
    }
}
