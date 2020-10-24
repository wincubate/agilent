using System.Threading;

namespace GracefulWorkerThreads
{
    interface IWorkerThreadWithResult<TInput,TResult> : IWorkerThread<TInput>
    {
        WaitHandle Completed { get; }
        TResult Result { get; }
    }
}