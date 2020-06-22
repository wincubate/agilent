using System.Drawing;

namespace Wincubate.Threading.ThreadPoolLabs
{
    class Input
    {
        public Color PixelColor { get; }
        public int X { get; }
        public int Y { get; }

        public Input(Color color, int x, int y)
        {
            PixelColor = color;
            X = x;
            Y = y;
        }
    }
}
