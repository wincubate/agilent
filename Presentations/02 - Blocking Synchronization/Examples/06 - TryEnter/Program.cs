using System;
using System.Threading;

namespace Wincubate.Threading.Module02
{
    class Program
    {
        static void Main()
        {
            Resource r = new Resource();

            Thread t1 = new Thread(r.Access);
            Thread t2 = new Thread(r.Access);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }

    class Resource
    {
        private int _counter;
        private readonly object _counterAccessSyncObject;

        public Resource()
        {
            _counterAccessSyncObject = new object();
        }
        public void Access()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 50; i++)
            {
                int temp = 0;
                bool wasAcquired = false;
                try
                {
                    wasAcquired = Monitor.TryEnter(_counterAccessSyncObject,TimeSpan.FromSeconds(2));
                    if( wasAcquired )
                    {
                        temp = _counter;
                        Thread.Sleep(r.Next(3));
                        temp++;
                        _counter = temp;
                    }
                }
                finally
                {
                    if( wasAcquired)
                    {
                        Monitor.Exit(_counterAccessSyncObject);
                    }
                }

                if( wasAcquired )
                {
                    Console.WriteLine(
                        $"Counter = {temp}. Thread: {Thread.CurrentThread.ManagedThreadId}"
                    );
                }

                Thread.Sleep(r.Next(10));
            }

            Console.WriteLine("Thread completed");
        }
    }
}
