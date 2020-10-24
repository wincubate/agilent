using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Wincubate.Threading.CaseStudyA
{
    public class Model
    {
        public string Fastest
        {
            get
            {
                return ComputeApproximation(5);
            }
        }

        public string Fast
        {
            get
            {
                return ComputeApproximation(30);
            }
        }

        public string Normal
        {
            get
            {
                return ComputeApproximation(50);
            }
        }

        public string Slow
        {
            get
            {
                return ComputeApproximation(75);
            }
        }

        public string Slowest
        {
            get
            {
                return ComputeApproximation(100);
            }
        }

        private string ComputeApproximation(int percentage, [CallerMemberName] string caller = null)
        {
            // Emulate slow computation...
            Thread.Sleep(percentage * 100);

            return string.Format("{2}:\t{0}\tThread Id={1}",
               caller,
               Thread.CurrentThread.ManagedThreadId,
               DateTime.Now
            );
        }
    }
}
