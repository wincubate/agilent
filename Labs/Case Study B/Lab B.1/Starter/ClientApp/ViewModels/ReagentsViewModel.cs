using Client.Contract;
using System;
using System.Collections.ObjectModel;
using System.Linq;
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
            ReagentViewModel itemVM = this.Items
                .SingleOrDefault(item => item.Serial == reagentItem.Serial)
                ;
            if( itemVM is null )
            {
                // First update for this serial
                Add(new ReagentViewModel(reagentItem));
            }
            else
            {
                itemVM.From(reagentItem);
            }

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
