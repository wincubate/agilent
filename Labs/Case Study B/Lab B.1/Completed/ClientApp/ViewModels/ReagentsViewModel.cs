using Client.Contract;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ClientApp.ViewModels
{
    class ReagentsViewModel : 
        ObservableCollection<ReagentViewModel>,
        IClientAsyncCallbackContract
    {
        private readonly ICanSendNotes _noteSender;

        public ReagentsViewModel(ICanSendNotes noteSender) => _noteSender = noteSender;

        #region IClientAsyncCallbackContract Members

        public Task ReagentItemUpdatedAsync(ReagentItem reagentItem)
        {
            ReagentViewModel itemVM = this.Items
                .SingleOrDefault(item => item.Serial == reagentItem.Serial)
                ;
            if( itemVM is null )
            {
                // First update for this serial
                Add(new ReagentViewModel(_noteSender,reagentItem));
            }
            else
            {
                itemVM.From(reagentItem);
            }

            return Task.CompletedTask;
        }

        public Task NoteUpdatedAsync(int reagentSerial, string note)
        {
            ReagentViewModel itemVM = this.Items
                .SingleOrDefault(item => item.Serial == reagentSerial)
                ;
            if (itemVM is null)
            {
                // First update for this serial
                Add(new ReagentViewModel(_noteSender,reagentSerial, note));
            }
            else
            {
                itemVM.From(note);
            }

            return Task.CompletedTask;
        }

        #endregion
    }
}
