using System;
using System.Collections.Generic;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            string text = "Hello, World";
            Thread t1 = new Thread(() => Console.WriteLine(text));

            text = "WTF?!?";
            Thread t2 = new Thread(() => Console.WriteLine(text));

            t1.Start();
            t2.Start();

            //List<Thread> threads = new List<Thread>();
            //for (int i = 0; i < 10; i++)
            //{
            //    Thread t = new Thread(() => Console.Write(i));
            //    t.Start();
            //    threads.Add(t);
            //}
            //Console.WriteLine();
        }
    }
}
