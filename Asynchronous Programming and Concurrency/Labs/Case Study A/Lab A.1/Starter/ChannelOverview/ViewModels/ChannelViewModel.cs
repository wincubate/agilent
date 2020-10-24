using ChannelOverview.Models;

namespace ChannelOverview.ViewModels
{
    class ChannelViewModel : ViewModelBase
    {
        public int Index { get; private set; }
        public string Description { get; private set; }

        public int SentCount
        {
            get => _sentCount;
            private set
            {
                if (_sentCount != value)
                {
                    _sentCount = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _sentCount;

        public int ReceivedCount
        {
            get => _receivedCount;
            private set
            {
                if (_receivedCount != value)
                {
                    _receivedCount = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _receivedCount;

        public string LatestStatus
        {
            get => _latestStatus;
            private set
            {
                if (_latestStatus != value)
                {
                    _latestStatus = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _latestStatus;


        public ChannelViewModel(ChannelMessage channelMessage)
        {
            UpdateWith(channelMessage);
        }

        public void UpdateWith(ChannelMessage channelMessage)
        {
            Index = channelMessage.Index;
            Description = $"Channel {Index:d2}";

            int count = channelMessage.MessageBuffer.Length;

            switch (channelMessage.Action)
            {
                case ChannelAction.Sent:
                    SentCount += count;
                    break;
                case ChannelAction.Received:
                    ReceivedCount += count;
                    break;
                default:
                    break;
            }

            LatestStatus = $"{count} chars {channelMessage.Action.ToString().ToLower()}: \"{channelMessage.MessageBuffer}\"";
        }
    }
}
