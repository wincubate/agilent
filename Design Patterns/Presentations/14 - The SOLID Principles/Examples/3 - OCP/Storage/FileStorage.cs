using System.IO;
using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class FileStorage : IStorage
    {
        public Task<string> GetDataAsStringAsync(string sourceFilePath) =>
            File.ReadAllTextAsync(sourceFilePath);

        public Task StoreDataAsStringAsync(
            string destinationFilePath,
            string outputDataAsString) =>
            File.WriteAllTextAsync(destinationFilePath, outputDataAsString);
    }
}
