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

            Task compoundCallbackTask = null;
            lock(_syncClients)
            {
                compoundCallbackTask = Task.WhenAll(
                    _clients
                        .Select(client => client.ReagentItemUpdatedAsync(updateToClients))
                        .ToArray()
                    )
                    ;
            }

            try
            {
                await compoundCallbackTask.ConfigureAwait(false); // <-- Due to await this only throws 
                                                                  // the FIRST exception - not an AggregateException
                                                                  // containing all...
            }
            catch
            {
                // ... but the compoundCallbackTask.Exception is exactly that AggregateException!
                AggregateException compoundException = compoundCallbackTask.Exception.Flatten();
                foreach (Exception exception in compoundException.InnerExceptions)
                {
                    if( exception is ObjectDisposedException )
                    {
                        // Silently ignore
                    }
                    else
                    {
                        _logger.LogError(exception);
                    }
                }
            }
        }

        public Task OnClientConnectedAsync(IClientAsyncCallbackContract client)
        {
            lock(_syncClients)
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
