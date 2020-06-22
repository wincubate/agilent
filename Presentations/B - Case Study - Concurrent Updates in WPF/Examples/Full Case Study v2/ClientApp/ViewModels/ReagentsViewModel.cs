using Client.Contract;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ClientApp.ViewModels
{
    class ReagentsViewModel : 
        ObservableCollection<ReagentViewModel>,
        IClientAsyncCallbackContract
    {
        #region IClientAsyncCallbackContract Members

        public Task ReagentItemUpdatedAsync(ReagentItem reagentItem)
        {
            Add(new ReagentViewModel(reagentItem));

            return Task.CompletedTask;
        }

        public Task NoteUpdatedAsync(int reagentSerial, string note)
        {
            Add(new ReagentViewModel(reagentSerial, note));

            return Task.CompletedTask;
        }

        #endregion
    }
}
