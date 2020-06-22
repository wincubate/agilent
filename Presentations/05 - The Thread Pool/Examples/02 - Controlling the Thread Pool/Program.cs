using System;
using System.Threading;

namespace Wincubate.Threading.Module05
{
    class Program
    {
        static void Main()
        {
            ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableCompletionPortThreads);
            Console.WriteLine($"{availableWorkerThreads} available worker threads");
            Console.WriteLine($"{availableCompletionPortThreads} available completion port threads\n");

            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);
            Console.WriteLine($"Max number of worker threads is: {maxWorkerThreads}");
            Console.WriteLine($"Max number of completion port threads is: {maxCompletionPortThreads}\n");

            ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
            Console.WriteLine($"Min number of worker threads is: {minWorkerThreads}");
            Console.WriteLine($"Min number of completion port threads is: {minCompletionPortThreads}\n");
        }
    }
}
