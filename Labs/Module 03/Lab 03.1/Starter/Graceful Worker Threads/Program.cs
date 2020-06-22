using System;

namespace GracefulWorkerThreads
{
    class Program
    {
        static void Main()
        {
            string htmlFileName = @"DifficultWords.txt";

            ExtractThread workerThread = new ExtractThread();
            workerThread.Start(htmlFileName);

            Console.ReadLine();

            workerThread.Kill(); // <-- Or could use the C# using construct
        }
    }
}
