using ChannelOverview.ViewModels;
using System;
using System.Text;
using System.Threading;

namespace ChannelOverview.Models
{
    class ChannelMessageWorkerThread : WorkerThreadBase<MainViewModel>
    {
        private readonly Random _random;
        private MainViewModel _vm;

        public ChannelMessageWorkerThread()
        {
            _random = new Random();
        }

        protected override void Work(MainViewModel input)
        {
            _vm = input;

            // Initial delay before outputting starts
            Thread.Sleep(1000);

            while (IsStopPending == false)
            {
                // Create random channel message
                int index = _random.Next(0, 6);
                ChannelAction action = (ChannelAction)_random.Next(0, 2);
                int messageBufferSize = _random.Next(0, 64);
                string messageBuffer = GenerateRandomString(messageBufferSize, false);

                ChannelMessage channelMessage = new ChannelMessage(index, action, messageBuffer);
                _vm.OnNewChannelMessage(channelMessage);

                Thread.Sleep(_random.Next(100, 500));
            }
        }

        // Generates a random string with a given size.    
        private string GenerateRandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}