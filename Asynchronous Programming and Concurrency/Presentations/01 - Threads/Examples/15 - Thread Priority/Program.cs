using System;
using System.Collections.Generic;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static volatile bool Done = false;

        static void Main()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            int countOfThreads = 15;
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < countOfThreads; i++)
            {
                Thread t = new Thread(Go)
                {
                    Priority = (ThreadPriority)(i % 5)
                };
                threads.Add(t);
            }

            threads.ForEach( t => t.Start() );
            Thread.Sleep(5000);

            Done = true;

            Console.ReadLine();
        }

        static void Go()
        {
            long counter = 0;
            while (!Done) // <-- Don't *really* do this ;-)
            {
                counter++;
            }

            Console.WriteLine( $"Thread with {Thread.CurrentThread.Priority} reached\t{counter}");
        }
    }
}
