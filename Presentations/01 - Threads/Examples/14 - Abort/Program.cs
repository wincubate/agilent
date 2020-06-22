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

            Thread.Sleep(2000);
            t.Abort();
        }

        static void Go()
        {
            try
            {
                Thread.Sleep(Timeout.Infinite);

                //for (int i = 0; i < 100; i++)
                //{
                //    Console.WriteLine($"{i} from thread {Thread.CurrentThread.ManagedThreadId}");

                //    // Blocking
                //    Thread.Sleep(100);
                //}
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Abort mission...!");

                //Thread.ResetAbort();
            }

            Console.WriteLine("Aborted"); // <-- WTF?
        }
    }
}
