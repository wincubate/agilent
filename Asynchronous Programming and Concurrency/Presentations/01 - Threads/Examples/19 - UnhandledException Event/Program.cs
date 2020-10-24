using System;
using System.Threading;

namespace Wincubate.Threading.Module01
{
    class Program
    {
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            Thread t = new Thread(Go);
            t.Start();
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Log
            Console.WriteLine((e.ExceptionObject as Exception).Message);

            // Excuse
            Console.WriteLine("Terribly sorry about that!");

            // Terminate?
            if (e.IsTerminating)
            {
                Console.WriteLine("Shutting doooooooooown...");
            }
        }

        static void Go()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i == 42)
                    {
                        throw new InvalidOperationException("Argh!");
                    }
                }
                Console.WriteLine("Thread completed!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Thread error");
            }
        }
    }
}
