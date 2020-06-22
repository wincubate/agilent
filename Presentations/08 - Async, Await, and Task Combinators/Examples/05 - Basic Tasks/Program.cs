using System;
using System.Threading;
using System.Threading.Tasks;

namespace Wincubate.Threading.Module08
{
    class Program
    {
        async static Task Main()
        {
            await Method1Async();

            DateTime now = await Method2Async();
            Console.WriteLine($"The time is now: {now.ToLongTimeString()}");

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.Cancel();
            try
            {
                await Method3Async(cts.Token);
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Task was cancelled!");
            }

            try
            {
                await Method4Async();
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Task threw an exception!");
            }
        }

        static Task Method1Async() => Task.CompletedTask;
        static Task<DateTime> Method2Async() => Task.FromResult(DateTime.Now);
        static Task<DateTime> Method3Async(CancellationToken cancellationToken) =>
            Task.FromCanceled<DateTime>(cancellationToken);
        static Task Method4Async() => Task.FromException(new NotImplementedException("Oops"));
    }
}
