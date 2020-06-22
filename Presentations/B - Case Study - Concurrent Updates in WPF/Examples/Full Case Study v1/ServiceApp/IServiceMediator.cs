using Client.Contract;
using Instrument.Contract;

namespace ServiceApp
{
    interface IServiceMediator
    {
        void OnReagentUpdated(ReagentUpdate update);
        void OnClientConnected(IClientCallbackContract client);
        void OnClientDisconnected(IClientCallbackContract client);
    }
}
