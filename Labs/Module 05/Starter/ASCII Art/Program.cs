using System;
using System.Drawing;
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

            for (int i = 0; i < height; i++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, i);

                    // Do lengthy computation to find nearest character and console color
                    AsciiArtHelper helper = new AsciiArtHelper();
                    var (asciiCharacter, consoleColor) = helper.ConvertColorToConsoleColoredChar(pixelColor);

                    // Draw character in console color at correct position
                    Console.ForegroundColor = consoleColor;
                    Console.Write(asciiCharacter);
                }
            }

            Console.ReadLine();
            Console.ForegroundColor = originalConsoleColor;
        }
    }
}
