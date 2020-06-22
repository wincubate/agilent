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
            Thread t2 = new Thread(new ThreadStart(a.Go));
            Thread t3 = new Thread( () =>
            {
                int counter = 0;
                for (int i = 0; i < 100; i++)
                {
                    counter++;
                    Console.WriteLine($"{counter} from thread {Thread.CurrentThread.ManagedThreadId}");
                }
            }
            );

            t1.Start();
            t2.Start();
            t3.Start();
        }
    }

    class A
    {
        private int _counter;

        public void Go()
        {
            for (int i = 0; i < 100; i++) // i is local to each thread
            {
                _counter += 1;
                Console.WriteLine($"{_counter} from thread {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}
