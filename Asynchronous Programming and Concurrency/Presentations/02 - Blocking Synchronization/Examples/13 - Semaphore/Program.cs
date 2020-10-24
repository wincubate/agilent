using System;
using System.Threading;

namespace Wincubate.Threading.Module02
{
    class Program
    {
        static void Main()
        {
            using (Resource r = new Resource())
            {
                Thread t1 = new Thread(r.Access);
                Thread t2 = new Thread(r.Access);
                Thread t3 = new Thread(r.Access);
                Thread t4 = new Thread(r.Access);
                Thread t5 = new Thread(r.Access);

                t1.Start();
                t2.Start();
                t3.Start();
                t4.Start();
                t5.Start();

                t1.Join();
                t2.Join();
                t3.Join();
                t4.Join();
                t5.Join();
            }
        }
    }

    class Resource : IDisposable
    {
        private readonly SemaphoreSlim _semaphore;

        public Resource()
        {
            _semaphore = new SemaphoreSlim(3);
        }

        public void Access()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    _semaphore.Wait();
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is in");
                    Thread.Sleep(r.Next(10));
                }
                finally
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is out");
                    _semaphore.Release();
                }

                Thread.Sleep(r.Next(10));
            }
        }

        public void Dispose() => _semaphore.Dispose();
    }
}
