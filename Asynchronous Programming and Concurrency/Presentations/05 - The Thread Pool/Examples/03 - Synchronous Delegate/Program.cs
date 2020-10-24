using System;
using System.Threading;

namespace Wincubate.Threading.Module05
{
    class Program
    {
        static void Main()
        {
            Func<int, int, int> del = Add;
            int result = del.Invoke(42, 87);
            Console.WriteLine(result);
        }

        static int Add(int a, int b)
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"Computing {a}+{b} on Thread {currentThread.ManagedThreadId} - " +
                               $"IsThreadPoolThread: {currentThread.IsThreadPoolThread}");
            return a + b;
        }

        static void PrintCurrentThread()
        {
            Thread currentThread = Thread.CurrentThread;
            Console.WriteLine($"On Thread {currentThread.ManagedThreadId} - " +
                              $"IsThreadPoolThread: {currentThread.IsThreadPoolThread}");
        }
    }
}
