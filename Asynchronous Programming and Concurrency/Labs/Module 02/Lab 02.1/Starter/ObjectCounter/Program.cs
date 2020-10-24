using System;

namespace ObjectCounter
{
    class Program
    {
        static void Main()
        {
            while( true )
            {
                Console.WriteLine( "Press ENTER to generate objects" );
                Console.ReadLine();

                for( int i = 0; i < 100000; i++ )
                {
                    A a = new A();
                }

                Console.WriteLine( "There are currently {0} instances of A", A.InstanceCount );
            }
        }
    }
}
