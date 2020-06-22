using System;
using Thread = System.Threading.Thread;
using System.Timers;

namespace Wincubate.Threading.Module05
{
    class Program
    {
        static void Main()
        {
            PrintCurrentThread();

            using (Timer timer = new Timer(3000))
            {
                timer.Elapsed += OnTimerElapsed;
                timer.AutoReset = false; // <-- Raise only once
                timer.Start();

                Console.ReadLine();
            }
        }

        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($"{sender.GetType().Name} says... The time is {e.SignalTime}");
            PrintCurrentThread();
        }

        static void OnTimerCallback(object data)
        {
        }

        static void PrintCurrentThread()
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"On Thread {currentThread.ManagedThreadId} - " +
                              $"IsThreadPoolThread: {currentThread.IsThreadPoolThread}");
        }
    }
}
