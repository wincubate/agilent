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

            Console.WriteLine("Waiting for results to be completed...");

            //workerThread.Completed.WaitOne();

            foreach (string word in workerThread.Result)
            {
                Console.WriteLine(word);
            }
        }
    }
}
