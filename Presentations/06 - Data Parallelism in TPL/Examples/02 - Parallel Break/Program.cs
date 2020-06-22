using System;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module06
{
    class Program
    {
        static void Main()
        {
            ParallelLoopResult result = Parallel.For(0, 1000, (i, state) =>
            {
                if (i == 87)
                {
                    state.Break();
                }
                else
                {
                    Console.WriteLine($"Executing number {i,4}...");
                }
            });

            if (result.IsCompleted == false && result.LowestBreakIteration.HasValue)
            {
                Console.WriteLine("Loop encountered a break at index {0}",
                    result.LowestBreakIteration.Value);
            }
        }
    }
}
