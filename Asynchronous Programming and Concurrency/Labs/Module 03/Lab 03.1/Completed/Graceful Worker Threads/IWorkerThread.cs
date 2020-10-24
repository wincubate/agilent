using System;

namespace GracefulWorkerThreads
{
    interface IWorkerThread<TInput> : IDisposable
    {
        void Start(TInput input);
        void Kill();
    }
}