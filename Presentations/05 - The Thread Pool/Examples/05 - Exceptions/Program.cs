using System;
using System.Threading;

namespace Wincubate.Threading.Module05
{
    class Program
    {
        static void Main()
        {
            Func<int, int, int> del = Add;
            IAsyncResult state = del.BeginInvoke(42, 87, null, null);

            // ...

            try
            {
                int result = del.EndInvoke(state);
                Console.WriteLine(result);
            }
            catch ( Exception exception )
            {
                Console.WriteLine( $"Whoops: {exception.Message}");
            }
        }

        static int Add(int a, int b)
        {
            throw new NotImplementedException("Sorry :-(");
        }
    }
}
