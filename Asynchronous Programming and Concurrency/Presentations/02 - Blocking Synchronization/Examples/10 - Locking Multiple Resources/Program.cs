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
        public int Counter1
        {
            get
            {
                lock (_counterFromAccessSyncObject)
                {
                    return _counterFrom;
                }
            }
        }
        public int Counter2
        {
            get
            {
                lock (_counterToAccessSyncObject)
                {
                    return _counterTo;
                }
            }
        }

        private int _counterFrom;
        private readonly object _counterFromAccessSyncObject;
        private int _counterTo;
        private readonly object _counterToAccessSyncObject;

        public Resource()
        {
            _counterFromAccessSyncObject = new object();
            _counterToAccessSyncObject = new object();

            _counterFrom = 100;
            _counterTo = 0;
        }

        public void Access()
        {
            for (int i = 0; i < 50; i++)
            {
                string message;
                lock (_counterFromAccessSyncObject)
                {
                    lock (_counterToAccessSyncObject)
                    {
                        _counterFrom--;
                        _counterTo++;

                        message = $"(From,To) = ({_counterFrom},{_counterTo}). Thread: {Thread.CurrentThread.ManagedThreadId}";
                        Thread.Sleep(1);
                    }
                }
                Console.WriteLine(message);
            }

            Console.WriteLine("Thread completed");
        }
    }
}