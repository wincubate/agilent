using Client.Contract;
using Instrument.Contract;
using System.Threading.Tasks;

namespace ServiceApp
{
    interface IAsyncServiceMediator
    {
        Task OnReagentUpdatedAsync(ReagentUpdate update);
        Task OnClientConnectedAsync(IClientAsyncCallbackContract client);
        Task OnClientDisconnectedAsync(IClientAsyncCallbackContract client);
    }
}
