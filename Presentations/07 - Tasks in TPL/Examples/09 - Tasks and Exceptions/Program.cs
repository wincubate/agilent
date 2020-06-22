using System;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module07
{
    class Program
    {
        static void Main()
        {
            Task<int> t = Task.Factory.StartNew(() =>
            {
                int k = 87;
                return 100 / (k - 87);
            }
            );

            try
            {
                t.Wait();
            }
            catch (AggregateException ae)
            {
                foreach (Exception e in ae.Flatten().InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadLine();
        }
    }
}
