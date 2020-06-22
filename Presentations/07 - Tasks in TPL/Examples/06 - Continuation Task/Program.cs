using System;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module07
{
    class Program
    {
        static void Main()
        {
            Task<DateTime> t1 = new Task<DateTime>(() => DateTime.Now);
            Task<string> t2 = t1.ContinueWith(previous => $"The time is {previous.Result}!");

            t1.Start();
            Console.WriteLine(t2.Result);
        }
    }
}
