using System;
using System.ServiceModel;

namespace Client.Contract
{
    [ServiceContract(
        CallbackContract = typeof(IClientCallbackContract),
        SessionMode = SessionMode.Required)]
    public interface IClientContract
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void Connect();

        [OperationContract(IsInitiating = false, IsTerminating = true)]
        void Disconnect();

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void SetNote(int reagentSerial, string note);
    }

    [ServiceContract]
    public interface IClientCallbackContract
    {
        [OperationContract]
        void ReagentItemUpdated(ReagentItem reagentItem);

        [OperationContract]
        void NoteUpdated(int reagentSerial, string note);
    }
}
