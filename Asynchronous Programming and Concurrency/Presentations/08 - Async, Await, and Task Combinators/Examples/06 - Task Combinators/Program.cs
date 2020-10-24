using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module08
{
    class Program
    {
        async static Task Main()
        {
            //Task<string[]> all = Task.WhenAll(
            //    FactorAsync(87),
            //    FactorAsync(112),
            //    FactorAsync(176)
            //);
            //string[] results = await all;

            //foreach (string result in results)
            //{
            //    Console.WriteLine(result);
            //}

            await Task.Delay(3000);
            Console.WriteLine("Done delaying...");
        }

        static Task<string> FactorAsync(int number)
        {
            PrimeHelper helper = new PrimeHelper();
            List<int> factors = helper.GetPrimeFactors(number);

            return Task.FromResult($"{number} = {string.Join("*", factors)}");
        }
    }
}
