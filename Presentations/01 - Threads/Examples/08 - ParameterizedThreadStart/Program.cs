using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            A a = new A();

            Thread t1 = new Thread(new ParameterizedThreadStart(a.Go));
            Thread t2 = new Thread(new ParameterizedThreadStart(a.Go));

            t1.Start(100);
            t2.Start(200);
        }
    }

    class A
    {
        private int _counter;

        public void Go(object input)
        {
            int max = (int)input;
            for (int i = 0; i < max; i++)
            {
                _counter += 1;
                Console.WriteLine($"{_counter} from thread {Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }
}
