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
                Thread t1 = new Thread(r.Access);
                Thread t2 = new Thread(r.Access);
                Thread t3 = new Thread(r.Access);
                Thread t4 = new Thread(r.Access);

                t1.Start();
                t2.Start();
                t3.Start();
                t4.Start();

                t1.Join();
                t2.Join();
                t3.Join();
                t4.Join();
            }
        }
    }

    class Resource : IDisposable
    {
        private readonly Barrier _barrier;
        private readonly Random _random;

        public Resource()
        {
            _barrier = new Barrier(4, barrier => Console.WriteLine($"{barrier.ParticipantCount}-thread rendezvous"));
            _random = new Random();
        }

        public void Access()
        {
            int i = 0;
            while (true)
            {
                Thread.Sleep(_random.Next(2000));
                _barrier.SignalAndWait();
                Console.WriteLine(i++);
            }
        }

        public void Dispose()
        {
            _barrier.Dispose();
        }
    }
}
