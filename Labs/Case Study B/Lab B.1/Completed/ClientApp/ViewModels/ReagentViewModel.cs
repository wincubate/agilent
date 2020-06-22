using Client.Contract;

namespace ClientApp.ViewModels
{
    class ReagentViewModel : ViewModelBase
    {
        #region Properties

        public int Serial
        {
            get => _serial;
            private set
            {
                if (_serial != value)
                {
                    _serial = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _serial;

        public string ProductName
        {
            get => _productName;
            private set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _productName;

        public string Location
        {
            get => _location;
            private set
            {
                if (_location != value)
                {
                    _location = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _location;

        public string Quantity
        {
            get => _quantity;
            private set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _quantity;

        public string Note
        {
            get => _note;
            set
            {
                if (_note != value)
                {
                    _note = value;
                    OnPropertyChanged();

                    // For simplicity we will just do this now even though it's not ideal as
                    // it will not ensure proper sequencing when multiple notes are sent.
                    //
                    // Better (but more complicated) alternatives would be e.g.
                    // 1) Use an outgoing queue, or
                    // 2) Use Stephen Cleary's Mvvm.Async library
                    _noteSender.SendNoteAsync(Serial, value);
                }
            }
        }
        private string _note;

        #endregion 

        private readonly ICanSendNotes _noteSender;

        private ReagentViewModel(ICanSendNotes noteSender)
        {
            _noteSender = noteSender;
        }

        public ReagentViewModel(ICanSendNotes noteSender, ReagentItem reagentItem) : this(noteSender)
        {
            Serial = reagentItem.Serial;
            From(reagentItem);
        }

        public ReagentViewModel(ICanSendNotes noteSender, int serial, string note) : this(noteSender)
        {
            Serial = serial;
            From(note);
        }

        public void From(ReagentItem reagentItem)
        {
            ProductName = reagentItem.ProductName;
            Location = reagentItem.Location;
            Quantity = reagentItem.Quantity.ToString("f2");
        }

        public void From(string note)
        {
            Note = note;
        }
    }
}
