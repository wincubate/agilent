using Client.Contract;
using System;

namespace ClientApp.ViewModels
{
    class ReagentViewModel : ViewModelBase
    {
        public int Serial
        {
            get => _serial;
            private set
            {
                if( _serial != value)
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
                }
            }
        }
        private string _note;

        public ReagentViewModel(ReagentItem reagentItem)
        {
            Serial = reagentItem.Serial;
            From(reagentItem);
        }

        public ReagentViewModel( int serial, string note)
        {
            Serial = serial;
            From(note);
        }

        public void From( ReagentItem reagentItem)
        {
            ProductName = reagentItem.ProductName;
            Location = reagentItem.Location;
            Quantity = reagentItem.Quantity.ToString("f2");
        }

        public void From( string note )
        {
            Note = note;
        }
    }
}
