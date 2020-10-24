using Client.Contract;
using Instrument.Contract;
using Middleware;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceApp
{
    class ServiceMeditator : IAsyncServiceMediator
    {
        private readonly ILogger _logger;
        private readonly ISet<IClientAsyncCallbackContract> _clients;

        public ServiceMeditator(ILogger logger)
        {
            _logger = logger;
            _clients = new HashSet<IClientAsyncCallbackContract>();
        }

        public async Task OnReagentUpdatedAsync(ReagentUpdate update)
        {
            _logger.LogReceived($"{update}");

            // Map to other representation (Note: We have deliberately not used the same type here)
            ReagentItem updateToClients = new ReagentItem
            {
                Serial = update.Serial,
                Location = update.Location,
                ProductName = update.ProductName,
                Quantity = update.Quantity
            };

            foreach (var client in _clients)
            {
                try
                {
                    await client.ReagentItemUpdatedAsync(updateToClients).ConfigureAwait(false);
                }
                catch(Exception exception)
                {
                    _logger.LogError(exception);
                }
            }
        }

        public Task OnClientConnectedAsync(IClientAsyncCallbackContract client)
        {
            _clients.Add(client);
            _logger.LogInfo($"Client connected {client.GetHashCode()}");

            return Task.CompletedTask;
        }

        public Task OnClientDisconnectedAsync(IClientAsyncCallbackContract client)
        {
            _clients.Remove(client);
            _logger.LogInfo($"Client disconnected {client.GetHashCode()}");

            return Task.CompletedTask;
        }
    }
}
