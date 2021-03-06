﻿using System;
using System.Threading;

namespace Wincubate.Threading.Module04
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

        public void Access()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < 50; i++)
            {
                int temp = Interlocked.Increment(ref _counter);

                // Interlocked.Read() is not necessary for 32-bit numbers (only for 64-bit numbers)
                // BUT can always use return values of Interlocked.Increment()
                Console.WriteLine(
                    $"Counter = {temp}. Thread: {Thread.CurrentThread.ManagedThreadId}" 
                );

                Thread.Sleep(r.Next(10));
            }

            Console.WriteLine("Thread completed");
        }
    }
}
