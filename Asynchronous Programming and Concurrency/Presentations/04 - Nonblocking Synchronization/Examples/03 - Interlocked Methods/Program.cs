using System;
using System.Diagnostics;
using System.Threading;

namespace Wincubate.Threading.Module04
{
    class Program
    {
        static long _a;

        static void Main(string[] args)
        {
            long b;

            b = Interlocked.Increment(ref _a);
            Debug.Assert(_a == 1);
            Debug.Assert(b == 1);

            b = Interlocked.Add(ref _a, 42);
            Debug.Assert(_a == 43);
            Debug.Assert(b == 43);
            
            Console.WriteLine(Interlocked.Read(ref _a));

            b = Interlocked.Exchange(ref _a, 87);
            Debug.Assert(_a == 87);
            Debug.Assert(b == 43);

            b = Interlocked.CompareExchange(ref _a, 176, 87); // if( _a == 87 ) { _a = 176; }
            Debug.Assert(_a == 176);
            Debug.Assert(b == 87);
            Console.WriteLine(Interlocked.Read(ref _a));
        }
    }
}
