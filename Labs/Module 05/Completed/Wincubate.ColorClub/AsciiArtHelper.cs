using System;
using System.Drawing;
using System.Threading;

namespace Wincubate.ColorClub
{
    /// <summary>
    /// Inspired by:
    /// https://stackoverflow.com/questions/32987103/image-to-ascii-art-conversion/32987834#32987834 
    /// https://stackoverflow.com/questions/28211009/what-are-the-actual-rgb-values-of-the-consolecolors
    /// http://colormine.org/
    /// https://www.thetopsites.net/article/52155621.shtml
    /// </summary>
    public class AsciiArtHelper
    {
        private readonly string _asciiChars = " .,:;ox%#@";
        private readonly ConsoleColorMapper _mapper;
        private readonly Random _random;

        public AsciiArtHelper()
        {
            _mapper = new ConsoleColorMapper(
                new ColorMetricDeltaStrategy()
            );
            _random = new Random();
        }

        public (char c, ConsoleColor consolecolor) ConvertColorToConsoleColoredChar(Color c)
        {
            float brightness = c.GetBrightness();
            int asciiIndexToUse = (int)Math.Floor(_asciiChars.Length * brightness);
            char charToUse = _asciiChars[asciiIndexToUse];

            ConsoleColor consoleColorToUse = _mapper.FindNearest(c);

            // Just to make it fun to parallelize ;-)
            Thread.Sleep(_random.Next(100));

            return (charToUse, consoleColorToUse);
        }
    }
}
