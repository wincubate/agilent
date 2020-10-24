using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleCalculator
{
    class ObservableObject : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged( [CallerMemberName] string propertyName = null ) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		#endregion
	}
}
