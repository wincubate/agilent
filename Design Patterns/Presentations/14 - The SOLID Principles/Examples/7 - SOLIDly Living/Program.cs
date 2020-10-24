using System.Collections;
using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class Program
    {
        static async Task Main(string[] args)
        {
            StockAnalyzer analyzer = new StockAnalyzer(
                new WebStorage(@"http://solid.wincubate.net/stockpositions.json"),
                new CompositeWriteStorage(
                    new ConsoleStorage(),
                    new RetryingWriteStorage(
                        new TwilioSmsTransmissionStorage("+4522123631")
                    )
                ),
                new JsonParser(),
                new CsvSerializer()
            );
            await analyzer.ProcessAsync();
        }
    }
}
