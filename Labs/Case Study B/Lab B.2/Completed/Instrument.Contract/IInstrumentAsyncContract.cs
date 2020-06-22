using System.ServiceModel;
using System.Threading.Tasks;

namespace Instrument.Contract
{
    [ServiceContract]
    public interface IInstrumentAsyncContract
    {
        [OperationContract]
        Task UpdateAsync(ReagentUpdate update);
    }
}
