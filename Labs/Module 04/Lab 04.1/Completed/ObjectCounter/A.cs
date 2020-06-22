using System.Threading;

namespace ObjectCounter
{
    class A
    {
        public static long InstanceCount => Interlocked.Read(ref _InstanceCount);
        private static long _InstanceCount;

        static A()
        {
            _InstanceCount = 0;
        }

        public A()
        {
            Interlocked.Increment(ref _InstanceCount);
        }

        ~A()
        {
            Interlocked.Decrement(ref _InstanceCount);
        }
    }
}
