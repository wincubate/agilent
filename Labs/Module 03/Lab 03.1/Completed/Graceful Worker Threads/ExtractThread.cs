using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace GracefulWorkerThreads
{
    class ExtractThread : WorkerThreadWithResultBase<string,IEnumerable<string>>
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

            IList<string> words = new List<string>();
            for (Match match = reg.Match(htmlFragment); match.Success && IsStopPending == false; match = match.NextMatch())
            {
                // Process match.Groups[1]
                words.Add(match.Groups[1].ToString());

                Thread.Sleep(25);
            }

            Result = words;
        }
    }
}
