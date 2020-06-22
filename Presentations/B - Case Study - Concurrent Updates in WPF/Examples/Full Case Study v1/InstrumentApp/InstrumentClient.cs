using Instrument.Contract;
using System;
using System.ServiceModel;

namespace InstrumentApp
{
    class InstrumentClient :
        ClientBase<IInstrumentContract>, 
        IDisposable
    {
        public InstrumentClient() : base(
            new WSHttpBinding(),
            new EndpointAddress(new Uri("http://localhost:8080/Instruments/"))
        )
        {
        }

        public void Update(ReagentUpdate update) => Channel.Update(update);
    }
}
