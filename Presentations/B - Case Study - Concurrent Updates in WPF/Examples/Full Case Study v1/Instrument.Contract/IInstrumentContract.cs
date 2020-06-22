using System.ServiceModel;

namespace Instrument.Contract
{
    [ServiceContract]
    public interface IInstrumentContract
    {
        [OperationContract]
        void Update(ReagentUpdate update);
    }
}
