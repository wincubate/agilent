using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            Thread t1 = new Thread(Go);
            Thread t2 = new Thread(Go);

            t1.Start();

            // Spinning
            for (int i = 0; i < 100_000_000; i++)
            {
                // Do nothing...
            }

            t2.Start();
        }

        static void Go()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{i} from thread {Thread.CurrentThread.ManagedThreadId}");
                
                // Blocking
                Thread.Sleep(1000);
            }
        }
    }
}
