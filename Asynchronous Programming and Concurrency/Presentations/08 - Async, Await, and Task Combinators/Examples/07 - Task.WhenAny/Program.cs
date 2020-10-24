using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module08
{
    class Program
    {
        async static Task Main()
        {
            List<Task<string>> remainingTasks = new List<Task<string>>
            {
                FactorAsync(87),
                FactorAsync(112),
                FactorAsync(176)
            };

            while( remainingTasks.Any() )
            {
                Task<string> completedTask = await Task.WhenAny(remainingTasks);
                Console.WriteLine(completedTask.Result);

                remainingTasks.Remove(completedTask);
            }
        }

        static Task<string> FactorAsync(int number)
        {
            PrimeHelper helper = new PrimeHelper();
            List<int> factors = helper.GetPrimeFactors(number);

            return Task.FromResult($"{number} = {string.Join("*", factors)}");
        }
    }
}
