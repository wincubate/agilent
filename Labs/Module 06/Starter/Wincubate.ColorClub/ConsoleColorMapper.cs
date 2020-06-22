using System;
using System.Drawing;
using System.Linq;

namespace Wincubate.ColorClub
{
    public class ConsoleColorMapper
    {
        private static ConsoleColorItem[] _consoleColorsItems = new ConsoleColorItem[]
        {
            new ConsoleColorItem( ConsoleColor.Black, Color.FromArgb(0x00, 0x00, 0x00) ),
            new ConsoleColorItem( ConsoleColor.DarkBlue, Color.FromArgb(0x00, 0x00, 0x80)),
            new ConsoleColorItem( ConsoleColor.DarkGreen, Color.FromArgb(0x00, 0x80, 0x00)),
            new ConsoleColorItem( ConsoleColor.DarkCyan, Color.FromArgb(0x00, 0x80, 0x80)),
            new ConsoleColorItem( ConsoleColor.DarkRed, Color.FromArgb(0x80, 0x00, 0x00)),
            new ConsoleColorItem( ConsoleColor.DarkMagenta, Color.FromArgb(0x80, 0x00, 0x80)),
            new ConsoleColorItem( ConsoleColor.DarkYellow, Color.FromArgb(0x80, 0x80, 0x00)),
            new ConsoleColorItem( ConsoleColor.Gray, Color.FromArgb(0xC0, 0xC0, 0xC0)),
            new ConsoleColorItem( ConsoleColor.DarkGray, Color.FromArgb(0x80, 0x80, 0x80)),
            new ConsoleColorItem( ConsoleColor.Blue, Color.FromArgb(0x00, 0x00, 0xFF)),
            new ConsoleColorItem( ConsoleColor.Green, Color.FromArgb(0x00, 0xFF, 0x00)),
            new ConsoleColorItem( ConsoleColor.Cyan, Color.FromArgb(0x00, 0xFF, 0xFF)),
            new ConsoleColorItem( ConsoleColor.Red, Color.FromArgb(0xFF, 0x00, 0x00)),
            new ConsoleColorItem( ConsoleColor.Magenta, Color.FromArgb(0xFF, 0x00, 0xFF)),
            new ConsoleColorItem( ConsoleColor.Yellow, Color.FromArgb(0xFF, 0xFF, 0x00)),
            new ConsoleColorItem( ConsoleColor.White, Color.FromArgb(0xFF, 0xFF, 0xFF))
        };

        private readonly IColorDistanceStrategy _colorDistanceStrategy;

        public ConsoleColorMapper(IColorDistanceStrategy colorDistanceStrategy)
        {
            _colorDistanceStrategy = colorDistanceStrategy;
        }

        public ConsoleColor FindNearest(Color original) =>
            _consoleColorsItems
                .Select(cci => new
                {
                    cci.ConsoleColor,
                    Delta = _colorDistanceStrategy.ComputeDistance(cci.Color, original)
                })
                .OrderBy(o => o.Delta)
                .First()
                .ConsoleColor
                ;
    }
}
