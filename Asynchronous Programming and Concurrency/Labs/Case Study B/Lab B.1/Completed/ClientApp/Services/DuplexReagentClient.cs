using Client.Contract;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    class DuplexReagentClient :
        DuplexClientBase<IClientAsyncContract>, 
        IClientAsyncContract,
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

        public Task ConnectAsync() => Channel.ConnectAsync();

        public Task SetNoteAsync(int serial, string note) => Channel.SetNoteAsync(serial, note);

        public Task DisconnectAsync() => Channel.DisconnectAsync();        
    }
}
