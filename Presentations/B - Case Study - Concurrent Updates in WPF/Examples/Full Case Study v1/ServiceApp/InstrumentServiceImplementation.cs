using Instrument.Contract;
using System.ServiceModel;

namespace ServiceApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class InstrumentServiceImplementation : IInstrumentContract
    {
        private readonly IServiceMediator _serviceMediator;

        public InstrumentServiceImplementation(IServiceMediator serviceMediator)
        {
            _serviceMediator = serviceMediator;
        }

        public void Update(ReagentUpdate update)
        {
            _serviceMediator.OnReagentUpdated(update);
        }
    }
}
