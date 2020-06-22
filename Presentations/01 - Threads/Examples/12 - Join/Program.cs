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

            t.Join();
            Console.WriteLine("t has completed!");
        }

        static void Go()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{i} from thread {Thread.CurrentThread.ManagedThreadId}");

                // Blocking
                Thread.Sleep(100);
            }
        }
    }
}
