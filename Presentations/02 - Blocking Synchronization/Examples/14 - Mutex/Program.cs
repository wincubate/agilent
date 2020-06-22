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
        private readonly Mutex _mutex;

        public Resource()
        {
            _mutex = new Mutex(false,"MyResourceMutex");
        }

        public void Access()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    _mutex.WaitOne();
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is in");
                    Thread.Sleep(r.Next(10));
                }
                finally
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is out");
                    _mutex.ReleaseMutex();
                }

                Thread.Sleep(r.Next(10));
            }
        }

        public void Dispose() => _mutex.Dispose();
    }
}
