using Library;
using System;
using System.Diagnostics;

namespace ProfilingWithProxy
{
    class Timing : IComputeOperation
    {
        private readonly Stopwatch _stopwatch;
        private readonly IComputeOperation _proxee;
        public Timing( IComputeOperation proxee )
        {
            _proxee = proxee;

            _stopwatch = new Stopwatch();
        }

        public void Compute( int range )
        {
            _stopwatch.Start();
            _proxee.Compute(range);
            _stopwatch.Stop();

            Console.WriteLine( $"Execution time was {_stopwatch.Elapsed}");
        }
    }
}