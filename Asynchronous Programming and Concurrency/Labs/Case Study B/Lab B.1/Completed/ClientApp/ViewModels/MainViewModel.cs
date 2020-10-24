using ClientApp.Services;
using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClientApp.ViewModels
{
    class MainViewModel :
        ViewModelBase,
        ICanSendNotes,
        IDisposable
    {
        #region Properties

        public ReagentsViewModel Reagents { get; private set; }

        #endregion

        #region Commands

        public ICommand ConnectCommand => _connectCommand;
        private readonly RelayCommand _connectCommand;

        public ICommand DisconnectCommand => _disconnectCommand;
        private readonly RelayCommand _disconnectCommand;

        public ICommand MakeMeSlowCommand => _makeMeSlowCommand;
        private readonly RelayCommand _makeMeSlowCommand;

        #endregion

        private bool _isConnected;
        private DuplexReagentClient _duplexClient;

        public MainViewModel()
        {
            _connectCommand = new RelayCommand(
                Connect,
                parameter => (_isConnected == false)
            );
            _disconnectCommand = new RelayCommand(
                Disconnect,
                parameter => (_isConnected == true)
            );
            _makeMeSlowCommand = new RelayCommand(
                p => Thread.Sleep(5000)
            );
            Reagents = new ReagentsViewModel(this);
            _isConnected = false;
        }

        private async void Connect(object parameter)
        {
            Reagents.Clear();

            _duplexClient = new DuplexReagentClient(new InstanceContext(Reagents));
            await _duplexClient.ConnectAsync();

            _isConnected = true;

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        private async void Disconnect(object parameter)
        {
            await _duplexClient.DisconnectAsync();
            (_duplexClient as IDisposable)?.Dispose();

            _isConnected = false;

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        public async Task SendNoteAsync(int serial, string note)
        {
            if (_isConnected)
            {
                await _duplexClient.SetNoteAsync(serial, note);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _duplexClient?.DisconnectAsync()
                .GetAwaiter()
                .GetResult();
            (_duplexClient as IDisposable)?.Dispose();
        }

        #endregion
    }
}
