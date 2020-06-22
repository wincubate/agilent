using System;
using System.Threading;

namespace Wincubate.Threading.Module03
{
    class Program
    {
        static void Main()
        {
            using (Resource r = new Resource())
            {
                Thread t1 = new Thread(r.Compute);
                Thread t2 = new Thread(r.Compute);
                Thread t3 = new Thread(r.Compute);
                Thread t4 = new Thread(r.Compute);
                Thread t5 = new Thread(r.Update);

                t1.Start(2);
                t2.Start(3);
                t3.Start(4);
                t4.Start(5);
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
        private object _numberAccessSyncObject;
        private int _number;
        private readonly EventWaitHandle _event;

        public Resource()
        {
            _numberAccessSyncObject = new object();
            _event = new ManualResetEvent(false);
            _number = 0;

            //_event = new EventWaitHandle(false, EventResetMode.ManualReset, "MyManualResetEvent")
        }

        public void Update()
        {
            for (int i = 0; i < 50; i += 10)
            {
                lock (_numberAccessSyncObject)
                {
                    _number = i;
                    Console.WriteLine($"Number set to {_number} by Thread {Thread.CurrentThread.ManagedThreadId}");
                }
                _event.Set();

                Thread.Sleep(1);

                _event.Reset();

                Thread.Sleep(1000);
            }
        }

        public void Compute(object factorObject)
        {
            int factor = (int)factorObject;

            for (int i = 0; i < 50; i++)
            {
                _event.WaitOne();
                lock (_numberAccessSyncObject)
                {
                    int result = factor * _number;
                    Console.WriteLine($"Number = {result} computed by Thread {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }

        public void Dispose() => _event.Dispose();
    }
}
