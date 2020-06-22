using System;
using System.Threading;

namespace Wincubate.Threading.Module05
{
    class Program
    {
        static void Main()
        {
            PrintCurrentThread();

            Func<int, int, int> del = Add;
            IAsyncResult state = del.BeginInvoke(42, 87, null, null);

            // ...

            int result = del.EndInvoke(state);
            Console.WriteLine( result );

            PrintCurrentThread();
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
