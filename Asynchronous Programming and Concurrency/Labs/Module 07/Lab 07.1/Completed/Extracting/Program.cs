using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

            Task<IEnumerable<string>> task = Task.Run(() =>
            {
                WordProcessor wp = new WordProcessor();
                return wp.ExtractFromFile(htmlFileName);
            });

            Console.WriteLine("Waiting for results to be completed...");

            foreach (string word in task.Result)
            {
                Console.WriteLine(word);
            }
        }
    }

    class WordProcessor
    {
        public IEnumerable<string> ExtractFromFile(string fileName)
        {
            string htmlFragment = File.ReadAllText(fileName);

            Regex reg = new Regex(@"word\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))",
                RegexOptions.IgnoreCase |
                RegexOptions.Compiled
            );

            IList<string> words = new List<string>();
            for (Match match = reg.Match(htmlFragment); match.Success; match = match.NextMatch())
            {
                // Process match.Groups[1]
                words.Add(match.Groups[1].ToString());

                //Thread.Sleep(25);
            }

            return words;
        }
    }
}
