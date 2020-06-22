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
                Thread t1 = new Thread(r.Read);
                Thread t2 = new Thread(r.Read);
                Thread t3 = new Thread(r.Read);
                Thread t4 = new Thread(r.Read);
                Thread t5 = new Thread(r.Write);

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
        private int _number;
        private readonly ReaderWriterLockSlim _rwLock;

        public Resource()
        {
            _rwLock = new ReaderWriterLockSlim();
        }

        public void Read()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 50; i++)
            {
                try
                {
                    _rwLock.EnterReadLock();
                    Console.WriteLine($"Number = {_number} read by Thread {Thread.CurrentThread.ManagedThreadId}");
                }
                finally
                {
                    _rwLock.ExitReadLock();
                }

                Thread.Sleep(r.Next(10));
            }
        }

        public void Write()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 50; i++)
            {
                try
                {
                    _rwLock.EnterWriteLock();
                    _number = r.Next(100);
                    Console.WriteLine($"Number = {_number} written by Thread {Thread.CurrentThread.ManagedThreadId}");
                }
                finally
                {
                    _rwLock.ExitWriteLock();
                }

                Thread.Sleep(r.Next(10));
            }
        }

        public void Dispose() => _rwLock.Dispose();
    }
}
