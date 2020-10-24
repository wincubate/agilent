using Client.Contract;
using Instrument.Contract;
using Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceApp
{
    class ServiceMeditator : IAsyncServiceMediator
    {
        private readonly ILogger _logger;
        private readonly ISet<IClientAsyncCallbackContract> _clients;
        private readonly object _syncClients;

        public ServiceMeditator(ILogger logger)
        {
            _logger = logger;
            _clients = new HashSet<IClientAsyncCallbackContract>();
            _syncClients = new object();
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

            Task[] callbackTasks = null;
            lock (_syncClients)
            {
                callbackTasks = _clients
                    .Select(client => client.ReagentItemUpdatedAsync(updateToClients))
                    .ToArray()
                    ;
            }

            try
            {
                await Task.WhenAll(callbackTasks).ConfigureAwait(false);
            }
            catch (ObjectDisposedException) {}
            catch (Exception exception)
            {
                _logger.LogError(exception);
            }
        }

        public Task OnClientConnectedAsync(IClientAsyncCallbackContract client)
        {
            lock (_syncClients)
            {
                _clients.Add(client);
            }
            _logger.LogInfo($"Client connected {client.GetHashCode()}");

            return Task.CompletedTask;
        }

        public Task OnClientDisconnectedAsync(IClientAsyncCallbackContract client)
        {
            lock (_syncClients)
            {
                _clients.Remove(client);
            }
            _logger.LogInfo($"Client disconnected {client.GetHashCode()}");

            return Task.CompletedTask;
        }
    }
}
