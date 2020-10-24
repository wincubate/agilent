namespace SimpleCalculator
{
    class Display : ObservableObject
	{
		public string Contents
		{
			get
			{
				return _contents;
			}
			private set
			{
				if( value != _contents )
				{
					_contents = value;
					OnPropertyChanged();
				}
			}
		}
		private string _contents;

		public bool IsEmpty
		{
			get
			{
				return Contents == "0";
			}
		}

		public Display()
		{
			Clear();
		}

		public void Clear()
		{
			Contents = "0";
		}

		public void Update( string digit )
		{
			if( Contents == "0" )
			{
				Contents = digit;
			}
			else
			{
				Contents += digit;
			}
		}
	}
}
