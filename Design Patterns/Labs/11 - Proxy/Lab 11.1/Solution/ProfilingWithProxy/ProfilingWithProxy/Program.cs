using Library;

namespace ProfilingWithProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IComputeOperation operation = new Timing( new ComputeOperation() );
            operation.Compute(100);
        }
    }
}
