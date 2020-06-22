using System;
using System.Threading;

namespace Wincubate.Threading.Module05
{
    class Program
    {
        static void Main()
        {
            PrintCurrentThread();

            using( Timer timer = new Timer(
                OnTimerCallback, 
                "System.Threading.Timer",
                2000,
                1000
                )
            )
            {
                //timer.Change(Timeout.Infinite, 0);

                Console.ReadLine();
            }
        }

        static void OnTimerCallback(object data)
        {
            Console.WriteLine( $"{data} says... The time is {DateTime.Now}");
            PrintCurrentThread();


        }

        static void PrintCurrentThread()
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"On Thread {currentThread.ManagedThreadId} - " +
                              $"IsThreadPoolThread: {currentThread.IsThreadPoolThread}");
        }
    }
}
