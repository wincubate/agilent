using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            A a = new A();

            Thread t1 = new Thread(a.PrintNumbers)
            {
                Name = "Number Printer Thread"
            };
            Thread t2 = new Thread(a.PrintQuestionMarks)
            {
                Name = "Question Marker Thread"
            };
            Thread t3 = new Thread(a.PrintLetters)
            {
                Name = "Letter Printer Thread"
            };

            t1.Start();
            t2.Start();
            t3.Start();

            Thread.Sleep(Timeout.Infinite);
        }
    }

    class A
    {
        public void PrintNumbers()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                Console.Write($"{random.Next(100),2} ");
            }
        }

        public void PrintQuestionMarks()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("?? ");
            }
        }

        public void PrintLetters()
        {
            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                char c = (char)random.Next(0x41, 0x5B);
                Console.Write($"{c}{c} ");
            }
        }
    }
}
