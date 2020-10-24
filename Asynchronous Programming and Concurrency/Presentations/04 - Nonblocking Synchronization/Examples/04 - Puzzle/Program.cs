using System;
using System.Threading;

namespace Wincubate.Threading.Module04
{
    class Program
    {
        static void Main()
        {
            A a = new A();

            Thread t1 = new Thread(a.Access1);
            Thread t2 = new Thread(a.Access2);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
        }
    }

    class A
    {
        private int _answer = 42;
        private bool _complete;

        public void Access1()
        {
            _answer = 87;
            _complete = true;
        }

        public void Access2()
        {
            if (_complete)
            {
                Console.WriteLine(_answer);
            }
        }
    }
}
