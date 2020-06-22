using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            Thread t = new Thread(WriteWorld);
            //t.IsBackground = true;
            t.Start();
        }

        static void WriteWorld()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void DeadOrAlive(Thread t)
        {
            Console.WriteLine($"Thread {t.ManagedThreadId} is {(t.IsAlive ? "Alive" : "Dead")}");
        }
    }
}
