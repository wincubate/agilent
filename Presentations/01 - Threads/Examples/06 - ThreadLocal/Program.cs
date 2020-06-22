using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            A a = new A();

            Thread t1 = new Thread(a.Go);
            Thread t2 = new Thread(a.Go);

            t1.Start();
            t2.Start();
        }
    }

    class A
    {
        private static ThreadLocal<int> _threadLocalCounter = new ThreadLocal<int>(
            () => 500
        );

        public void Go()
        {
            for (int i = 0; i < 100; i++) // i is local to each thread
            {
                _threadLocalCounter.Value++;
                Console.WriteLine($"{_threadLocalCounter.Value} from thread {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}
