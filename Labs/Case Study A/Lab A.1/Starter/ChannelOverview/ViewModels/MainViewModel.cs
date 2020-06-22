using ChannelOverview.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ChannelOverview.ViewModels
{
    class MainViewModel : ViewModelBase, IDisposable
    {
        public ICommand CloseCommand => _closeCommand;
        private readonly RelayCommand _closeCommand;

        public ObservableCollection<ChannelViewModel> Channels { get; private set; }

        private readonly IWorkerThread<MainViewModel> _channelMessageProducer;

        public MainViewModel()
        {
            _closeCommand = new RelayCommand(_ =>
            {
                _channelMessageProducer.Dispose();
            });

            Channels = new ObservableCollection<ChannelViewModel>();

            _channelMessageProducer = new ChannelMessageWorkerThread();
            _channelMessageProducer.Start(this);
        }

        // This will be called on a non-Dispatcher thread
        internal void OnNewChannelMessage(ChannelMessage channelMessage)
        {
            // TODO: Handle updates from worker thread correctly such that
            // 1) When the first ChannelMessage for a specified Index is encountered,
            //    a new, the view is updated with a new ChannelViewModel appropriately initialized
            //    with the data in the channelMessage.
            // 2) When a ChannelMessage for a ChannelViewModel already existing in the UI is encountered,
            //    the existing ChannelViewModel is updated using ChannelViewModel.UpdateWith()
        }

        public void Dispose()
        {
            _channelMessageProducer.Dispose();
        }
    }
}
