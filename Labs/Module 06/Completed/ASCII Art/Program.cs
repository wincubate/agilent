using System;
using System.Drawing;
using System.Threading.Tasks;
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

            // Note: Bitmap is not thread-safe, so we cannot concurrently invoke GetPixel(x,y),
            // even if it only reads. Hence, we calculate all inputs sequentially first...
            Input[] inputs = new Input[width * height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    inputs[y * width + x] = new Input(color, x, y);
                }
            }

            // ... and then use these to compute all computations concurrently
            Parallel.For(0, inputs.Length, i => Compute(inputs[i]));

            Console.ReadLine();
            Console.ForegroundColor = originalConsoleColor;
        }

        static void Compute(Input input)
        {
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
