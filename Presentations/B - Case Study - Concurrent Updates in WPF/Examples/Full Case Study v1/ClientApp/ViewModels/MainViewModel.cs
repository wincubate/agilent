using ClientApp.Services;
using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Input;

namespace ClientApp.ViewModels
{
    class MainViewModel :
        ViewModelBase, 
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
            Reagents = new ReagentsViewModel();
            _isConnected = false;
        }

        private void Connect(object parameter)
        {
            Reagents.Clear();

            _duplexClient = new DuplexReagentClient(new InstanceContext(Reagents));
            _duplexClient.Connect();

            _isConnected = true;
        }

        private void Disconnect(object parameter)
        {
            _duplexClient.Disconnect();
            (_duplexClient as IDisposable)?.Dispose();

            _isConnected = false;
        }

        #region IDisposable Members

        public void Dispose()
        {
            _duplexClient?.Disconnect();
            (_duplexClient as IDisposable)?.Dispose();
        }

        #endregion
    }
}
