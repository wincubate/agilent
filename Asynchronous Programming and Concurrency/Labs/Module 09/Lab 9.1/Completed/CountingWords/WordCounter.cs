using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CountingWords
{
    class WordCounter
    {
        public IDictionary<string, int> CountMap => _countMap;
        private readonly ConcurrentDictionary<string, int> _countMap;

        public WordCounter()
        {
            // TODO: Initialize _countMap
            _countMap = new ConcurrentDictionary<string, int>();
        }

        public void AddToCount(string fileName)
        {
            string contents = File.ReadAllText(fileName);
            IEnumerable<string> words = contents
                .ToLower()
                .Split(' ', ',', '.', ':', ';', '!', '?', '[', ']', '\n', '\r', '\t')
                .Where( s => string.IsNullOrWhiteSpace(s) == false)
                ;

            foreach (string word in words)
            {
                // TODO: Update _countMap in a thread-safe manner
                _countMap.AddOrUpdate(word, 1, (w, i) => i + 1);
            }
        }
    }
}
