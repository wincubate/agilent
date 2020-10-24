using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            Thread thread = new Thread(WriteWorld);
            thread.Start();

            for (int i = 0; i < 100; i++)
            {
                Console.Write("Hello ");
            }
        }

        static void WriteWorld()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("World ");
            }
        }
    }
}
