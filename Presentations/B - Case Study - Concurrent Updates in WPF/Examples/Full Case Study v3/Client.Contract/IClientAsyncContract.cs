using System.ServiceModel;
using System.Threading.Tasks;

namespace Client.Contract
{
    [ServiceContract(
        CallbackContract = typeof(IClientAsyncCallbackContract),
        SessionMode = SessionMode.Required)]
    public interface IClientAsyncContract
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        Task ConnectAsync();

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        Task DisconnectAsync();

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        Task SetNoteAsync(int reagentSerial, string note);
    }

    [ServiceContract]
    public interface IClientAsyncCallbackContract
    {
        [OperationContract]
        Task ReagentItemUpdatedAsync(ReagentItem reagentItem);

        [OperationContract]
        Task NoteUpdatedAsync(int reagentSerial, string note);
    }
}
