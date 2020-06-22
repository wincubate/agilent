using System;
using System.Drawing;

namespace Wincubate.ColorClub
{
    public readonly struct ConsoleColorItem
    {
        public ConsoleColor ConsoleColor { get; }
        public Color Color { get; }

        public ConsoleColorItem(ConsoleColor consoleColor, Color color)
        {
            ConsoleColor = consoleColor;
            Color = color;
        }
    }
}
