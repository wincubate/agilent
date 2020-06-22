using Client.Contract;
using Instrument.Contract;
using Middleware;
using System;
using System.Collections.Generic;

namespace ServiceApp
{
    class ServiceMeditator : IServiceMediator
    {
        private readonly ILogger _logger;
        private readonly ISet<IClientCallbackContract> _clients;

        public ServiceMeditator(ILogger logger)
        {
            _logger = logger;
            _clients = new HashSet<IClientCallbackContract>();
        }

        public void OnReagentUpdated(ReagentUpdate update)
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
                    client.ReagentItemUpdated(updateToClients);
                }
                catch(Exception exception)
                {
                    _logger.LogError(exception);
                }
            }
        }

        public void OnClientConnected(IClientCallbackContract client)
        {
            _clients.Add(client);
            _logger.LogInfo($"Client connected {client.GetHashCode()}");
        }

        public void OnClientDisconnected(IClientCallbackContract client)
        {
            _clients.Remove(client);
            _logger.LogInfo($"Client disconnected {client.GetHashCode()}");
        }
    }
}
