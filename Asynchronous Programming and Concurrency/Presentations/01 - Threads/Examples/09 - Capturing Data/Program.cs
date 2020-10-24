using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            int max = 250;
            Thread t1 = new Thread(() =>
            {
                int counter = 0;
                for (int i = 0; i < max; i++)
                {
                    counter++;
                    Console.WriteLine($"{counter} from thread {Thread.CurrentThread.ManagedThreadId}");
                }
            }
            );

            t1.Start();
        }
    }
}
