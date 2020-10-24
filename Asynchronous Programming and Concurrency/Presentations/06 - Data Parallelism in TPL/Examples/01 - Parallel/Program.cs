using System;
using System.Collections.Generic;

namespace Wincubate.Threading.Module06
{
    class Program
    {
        static void Main()
        {
            void action1()
            {
                for (int i = 0; i < 100; i += 2)
                {
                    Console.WriteLine(i);
                }
            }

            void action2()
            {
                for (int i = 1; i < 100; i += 2)
                {
                    Console.WriteLine("\t" + i);
                }
            }

            void action3()
            {
                for (int i = 0; i > -100; i -= 2)
                {
                    Console.WriteLine("\t\t" + i);
                }
            }

            action1();
            action2();
            action3();

            //for (int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine($"Executing number {i,4}...");
            //}

            //IEnumerable<int> list = Enumerable.Range(0, 1000);
            //foreach (int i in list)
            //{
            //    Console.WriteLine($"Executing number {i,4}...");
            //}

            #region Parallel.Invoke()

            //Action action1 = () =>
            //{
            //   for( int i = 0; i < 100; i += 2 )
            //   {
            //      Console.WriteLine( i );
            //   }
            //};

            //Action action2 = () =>
            //{
            //   for ( int i = 1 ; i < 100 ; i += 2 )
            //   {
            //      Console.WriteLine( "\t" + i );
            //   }
            //};

            //Action action3 = () =>
            //{
            //   for ( int i = 0 ; i > -100 ; i -= 2 )
            //   {
            //      Console.WriteLine( "\t\t" + i );
            //   }
            //};

            //Parallel.Invoke( action1, action2, action3 );

            #endregion

            #region Parallel.For()

            //Parallel.For(0, 1000, i =>
            //   Console.WriteLine($"Executing number {i,4}...")
            //);
            #endregion

            #region Parallel.ForEach()
            //IEnumerable<int> list = Enumerable.Range(0, 1000);
            //Parallel.ForEach(list, i =>
            //   Console.WriteLine($"Executing number {i,4}...")
            //);
            #endregion

            Console.ReadLine();
        }
    }
}
