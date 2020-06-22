using System;
using System.Drawing;
using System.Threading;
using Wincubate.ColorClub;

namespace Wincubate.Threading.ThreadPoolLabs
{
    class Program
    {
        static void Main()
        {
            Bitmap bitmap = new Bitmap("Mario.bmp");

            int width = bitmap.Width;
            int height = bitmap.Height;

            Console.SetWindowSize(width, height + 1);
            Console.BufferWidth = width;
            Console.BufferHeight = height + 1;

            ConsoleColor originalConsoleColor = Console.ForegroundColor;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    ThreadPool.QueueUserWorkItem(Compute, new Input(color, x, y));
                }
            }
            
            Console.ReadLine();
            Console.ForegroundColor = originalConsoleColor;
        }

        static void Compute(object data)
        {
            Input input = data as Input;

            // Do lengthy computation to find nearest character and console color
            AsciiArtHelper helper = new AsciiArtHelper();
            var (asciiCharacter, consoleColor) = helper.ConvertColorToConsoleColoredChar(input.PixelColor);

            lock (typeof(Console))
            {
                // Draw character in conosle color at correct position
                Console.ForegroundColor = consoleColor;
                Console.SetCursorPosition(input.X, input.Y);
                Console.Write(asciiCharacter);
            }
        }
    }
}
