namespace ObjectCounter
{
    class A
    {
        public static long InstanceCount
        {
            get
            {
                lock( typeof( A ) )
                {
                    return _InstanceCount;
                }
            }
        }
        private static long _InstanceCount;

        static A()
        {
            _InstanceCount = 0;
        }

        public A()
        {
            lock( typeof( A ) )
            {
                _InstanceCount++;
            }
        }

        ~A()
        {
            lock( typeof( A ) )
            {
                _InstanceCount--;
            }
        }
    }
}
