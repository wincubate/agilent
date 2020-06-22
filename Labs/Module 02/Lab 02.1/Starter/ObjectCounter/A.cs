namespace ObjectCounter
{
    class A
    {
        public static long InstanceCount;

        static A()
        {
            InstanceCount = 0;
        }

        public A()
        {
            InstanceCount++;
        }

        ~A()
        {
            InstanceCount--;
        }
    }
}
