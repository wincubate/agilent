using System;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module07
{
    class Program
    {
        static void Main()
        {
            Task<DateTime> t = Task.Run<DateTime>(() => DateTime.Now);

            Console.WriteLine(t.Result);
        }
    }
}
