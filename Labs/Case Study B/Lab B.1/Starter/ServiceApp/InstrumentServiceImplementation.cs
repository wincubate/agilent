using Instrument.Contract;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ServiceApp
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class InstrumentServiceImplementation : IInstrumentAsyncContract
    {
        private readonly IAsyncServiceMediator _serviceMediator;

        public InstrumentServiceImplementation(IAsyncServiceMediator serviceMediator)
        {
            _serviceMediator = serviceMediator;
        }

        public Task UpdateAsync(ReagentUpdate update) => _serviceMediator.OnReagentUpdatedAsync(update);
    }
}
