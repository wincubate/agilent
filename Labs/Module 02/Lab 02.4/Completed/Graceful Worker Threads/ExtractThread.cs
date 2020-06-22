using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace GracefulWorkerThreads
{
    class ExtractThread : WorkerThreadBase<string>
    {
        private readonly Regex reg;

        public ExtractThread()
        {
            reg = new Regex(@"word\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))",
                RegexOptions.IgnoreCase | 
                RegexOptions.Compiled
            );
        }

        protected override void Work( string fileName )
        {
            string htmlFragment = File.ReadAllText(fileName);

            for (Match match = reg.Match(htmlFragment); match.Success && IsStopPending == false; match = match.NextMatch())
            {
                // Process match.Groups[1]
                Console.WriteLine(match.Groups[1].ToString());

                Thread.Sleep(25);
            }
        }
    }
}
