using Polly;
using System;
using System.Threading.Tasks;

namespace Wincubate.Solid
{
    class RetryingWriteStorage : IWriteStorage
    {
        private readonly IWriteStorage _proxee;

        public RetryingWriteStorage(IWriteStorage proxee) =>
            _proxee = proxee;

        public Task StoreDataAsStringAsync(string outputDataAsString)
        {
            IAsyncPolicy policy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2))
                ;
            return policy.ExecuteAsync(() => _proxee.StoreDataAsStringAsync(outputDataAsString));
        }
    }
}
