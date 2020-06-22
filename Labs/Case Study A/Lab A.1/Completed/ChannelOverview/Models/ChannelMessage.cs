namespace ChannelOverview.Models
{
    class ChannelMessage
    {
        public int Index { get; set; }
        public ChannelAction Action { get; set; }

        public string MessageBuffer { get; set; }

        public ChannelMessage(int index, ChannelAction action, string messageBuffer)
        {
            Index = index;
            Action = action;
            MessageBuffer = messageBuffer;
        }
    }
}
