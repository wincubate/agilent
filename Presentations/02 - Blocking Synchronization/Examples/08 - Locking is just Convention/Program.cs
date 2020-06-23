using System;
using System.Threading;

namespace Wincubate.Threading.Module02
{
    class Program
    {
        static void Main()
        {
            Resource r = new Resource();

            Thread t1 = new Thread(r.Access1);
            Thread t2 = new Thread(r.Access2);

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

        public void Access1()
        {
            for (int i = 0; i < 50; i++)
            {
                int temp;
                lock (_counterAccessSyncObject)
                {
                    temp = _counter;
                    Thread.Sleep(3);
                    temp++;
                    _counter = temp;
                }

                Console.WriteLine(
                    $"Counter = {temp}. Thread: {Thread.CurrentThread.ManagedThreadId}"
                );
            }

            Console.WriteLine("Thread 2 completed");
        }

        public void Access2()
        {
            for (int i = 0; i < 50; i++)
            {
                int temp;
                lock (_counterAccessSyncObject)
                {
                    temp = _counter;
                    Thread.Sleep(2);
                    temp++;
                    _counter = temp;
                }

                Console.WriteLine(
                    $"Counter = {temp}. Thread: {Thread.CurrentThread.ManagedThreadId}"
                );
            }

            Console.WriteLine("Thread 2 completed");
        }
    }
}