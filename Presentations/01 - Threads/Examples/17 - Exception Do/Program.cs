using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            Thread t = new Thread(Go);
            t.Start();
        }

        static void Go()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 42)
                    {
                        throw new InvalidOperationException("Argh!");
                    }
                }
                Console.WriteLine("Thread completed!");
            }
            catch (Exception)
            {
                Console.WriteLine("Thread error");
            }
        }
    }
}
