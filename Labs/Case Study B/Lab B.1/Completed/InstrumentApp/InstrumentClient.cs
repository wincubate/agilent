using Instrument.Contract;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace InstrumentApp
{
    class InstrumentClient :
        ClientBase<IInstrumentAsyncContract>, 
        IDisposable
    {
        public InstrumentClient() : base(
            new WSHttpBinding(),
            new EndpointAddress(new Uri("http://localhost:8080/Instruments/"))
        )
        {
        }

        public Task UpdateAsync(ReagentUpdate update) => Channel.UpdateAsync(update);
    }
}
