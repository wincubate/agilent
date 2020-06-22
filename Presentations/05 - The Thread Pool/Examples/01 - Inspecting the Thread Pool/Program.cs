using System;
using System.Threading;

namespace Wincubate.Threading.Module05
{
    class Program
    {
        static void Main()
        {
            PrintAvailableThreads();

            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(Go, i);
                //ThreadPool.QueueUserWorkItem(_ => Console.WriteLine(i));
            }

            // Wait for CR
            Console.ReadLine();

            PrintAvailableThreads();
        }

        static void Go(object number)
        {
            ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out _);
            Console.WriteLine($"{number} printed by {Thread.CurrentThread.ManagedThreadId} [{availableWorkerThreads} left]");

            //Random r = new Random();
            //Thread.Sleep(r.Next(100));
        }

        static void PrintAvailableThreads()
        {
            ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableCompletionPortThreads);
            Console.WriteLine($"{availableWorkerThreads} available worker threads");
            Console.WriteLine($"{availableCompletionPortThreads} available completion port threads\n");
        }
    }
}
