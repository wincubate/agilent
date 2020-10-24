using Client.Contract;
using System;
using System.Collections.ObjectModel;

namespace ClientApp.ViewModels
{
    class ReagentsViewModel : 
        ObservableCollection<ReagentViewModel>,
        IClientCallbackContract
    {
        #region IReagentClientCallbackContract Members

        public void ReagentItemUpdated(ReagentItem reagentItem)
        {
            Add(new ReagentViewModel(reagentItem));
        }

        public void NoteUpdated(int reagentSerial, string note)
        {
            Add(new ReagentViewModel(reagentSerial, note));
        }

        #endregion
    }
}
