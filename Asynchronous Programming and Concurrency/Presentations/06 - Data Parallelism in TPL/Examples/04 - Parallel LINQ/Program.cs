using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module06
{
    class Program
    {
        static void Main()
        {
            bool Filter(int i)
            {
                Random r = new Random();
                Thread.SpinWait(r.Next(25_000_000));

                return i % 2 == 0;
            }

            IEnumerable<int> numbers = Enumerable.Range(1, 100);

            var even = numbers
                .Where(Filter)
                ;

            foreach (int i in even)
            {
                Console.WriteLine(i);
            }
        }
    }
}
