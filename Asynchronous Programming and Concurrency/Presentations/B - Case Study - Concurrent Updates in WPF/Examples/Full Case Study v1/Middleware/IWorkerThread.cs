using System;

namespace Middleware
{
    public interface IWorkerThread<TInput> : IDisposable
    {
        void Start(TInput input);
        void Kill();
    }
}
