using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            try
            {
                Thread t = new Thread(() =>
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (i == 42)
                        {
                            throw new InvalidOperationException("Argh!");
                        }
                    }
                    Console.WriteLine("Thread completed!");
                });
                t.Start();
            }
            catch (Exception)
            {
                Console.WriteLine("Thread error");
            }
        }
    }
}
