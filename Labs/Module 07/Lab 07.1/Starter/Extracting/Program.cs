using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

/// <summary>
/// Data from https://www.vocabulary.com/lists/191545 .
/// </summary>
namespace Counting
{
    class Program
    {
        static void Main()
        {
            string htmlFileName = @"DifficultWords.txt";

            Thread thread = new Thread(() =>
            {
               WordProcessor wp = new WordProcessor();
               wp.ExtractFromFile(htmlFileName);
            });
            thread.Start();
        }
    }

    class WordProcessor
    {
        public void ExtractFromFile(string fileName)
        {
            string htmlFragment = File.ReadAllText(fileName);

            Regex reg = new Regex(@"word\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))",
               RegexOptions.IgnoreCase | RegexOptions.Compiled);

            for (Match match = reg.Match(htmlFragment); match.Success; match = match.NextMatch())
            {
                // Process match.Groups[1]
                Console.WriteLine(match.Groups[1].ToString());

                Thread.Sleep(25);
            }
        }
    }
}
