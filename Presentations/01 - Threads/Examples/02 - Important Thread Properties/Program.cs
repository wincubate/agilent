using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            Thread t = new Thread(WriteWorld);
            DeadOrAlive(Thread.CurrentThread);
            DeadOrAlive(t);
            
            t.Start();
            DeadOrAlive(Thread.CurrentThread);
            DeadOrAlive(t);

            for (int i = 0; i < 10; i++)
            {
                Console.Write("Hello ");
            }

            Console.ReadLine();
            DeadOrAlive(Thread.CurrentThread);
            DeadOrAlive(t);
        }

        static void WriteWorld()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write("World ");
            }
        }

        static void DeadOrAlive(Thread t)
        {
            Console.WriteLine($"Thread {t.ManagedThreadId} is {(t.IsAlive ? "Alive" : "Dead")}");
        }
    }
}
