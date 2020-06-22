using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module06
{
    class Program
    {
        static void Main()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            ParallelOptions options = new ParallelOptions();
            options.CancellationToken = token;
            //            options.MaxDegreeOfParallelism = 1;

            try
            {
                Parallel.For(0, 1000, options, i =>
                {
                    if (i == 87)
                    {
                        // Note: This is some external source cancelling!
                        cts.Cancel();
                    }
                    else
                    {
                        Console.WriteLine($"Executing number {i,4}...");
                    }
                });
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was cancelled");
            }
        }
    }
}
