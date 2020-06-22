using System.Threading.Tasks;

namespace CountingWords
{
    class Program
    {
        static async Task Main()
        {
            WordCounter wordCounter = new WordCounter();

            string[] fileNames = {
                @"Files\macbeth.txt",
                @"Files\matrix.txt",
                @"Files\Mandalorian Episode 1-1.txt",
            };

            // TODO: Start one task for each file name which invokes wordCounter.AddToCount for each file name
            // ...

            // TODO: When all tasks have completed, print the 25 most frequently occurring words
            var topWords = wordCounter.CountMap
                // ...
                ;

            // TODO: Process topWords
        }
    }
}
