using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module09
{
    class Program
    {
        async static Task Main()
        {
            int countOfItems = 1000;
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();

            Task producer = Task.Factory.StartNew(
               () =>
               {
                   Random r = new Random();
                   for (int i = 0; i < countOfItems; i++)
                   {
                       queue.Enqueue(r.Next(1000000));
                   }
               }
            );

            Task consumer = Task.Factory.StartNew(
               () =>
               {
                   PrimeHelper helper = new PrimeHelper();
                   for (int i = 0; i < countOfItems;)
                   {
                       if (queue.TryDequeue(out int number))
                       {
                           List<int> factors = helper.GetPrimeFactors(number);

                           Console.WriteLine($"{number} = {string.Join("*", factors)}");
                           i++;
                       }
                   }
               }
            );

            await Task.WhenAll(producer, consumer);

            Console.WriteLine("Done...");
        }
    }
}
