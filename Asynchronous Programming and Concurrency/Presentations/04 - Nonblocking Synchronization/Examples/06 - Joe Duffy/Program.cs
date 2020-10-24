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
        volatile int x, y;

        public void Access1()
        {
            x = 1;            // Volatile write (release-fence)
            int a = y;        // Volatile read (acquire-fence)
            Console.WriteLine(a);
        }

        public void Access2()
        {
            y = 1;            // Volatile write (release-fence)
            int b = x;        // Volatile read (acquire-fence)
            Console.WriteLine(b);
        }
    }
}
