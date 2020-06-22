using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Wincubate.Threading.Module03
{
    class Program
    {
        static void Main()
        {
            using (Resource r = new Resource())
            {
                Thread t1 = new Thread(r.Access1);
                Thread t2 = new Thread(r.Access2);

                t1.Start();
                t2.Start();

                t1.Join();
                t2.Join();
            }
        }
    }

    class Resource : IDisposable
    {
        private readonly WaitHandle _oneToTwo;
        private readonly WaitHandle _twoToOne;

        private readonly Random _random;

        public Resource()
        {
            _oneToTwo = new AutoResetEvent(false);
            _twoToOne = new AutoResetEvent(false);

            _random = new Random();
        }

        public void Access1()
        {
            while (true)
            {
                Thread.Sleep(_random.Next(2000));
                WaitHandle.SignalAndWait(_oneToTwo, _twoToOne);
                Console.WriteLine( "Thread Rendezvous at Thread 1");
            }
        }

        public void Access2()
        {
            while (true)
            {
                Thread.Sleep(2000 + _random.Next(5000));
                WaitHandle.SignalAndWait(_twoToOne, _oneToTwo);
                Console.WriteLine("Thread Rendezvous at Thread 2");
            }
        }

        public void Dispose()
        {
            _oneToTwo.Dispose();
            _twoToOne.Dispose();
        }
    }
}
