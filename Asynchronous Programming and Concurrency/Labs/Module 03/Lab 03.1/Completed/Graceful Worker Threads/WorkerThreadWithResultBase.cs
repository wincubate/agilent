using System.Threading;

namespace GracefulWorkerThreads
{
    public abstract class WorkerThreadWithResultBase<TInput, TResult> : WorkerThreadBase<TInput>
    {
        public WaitHandle Completed => _ranToCompletionEvent;
        private readonly ManualResetEvent _ranToCompletionEvent;

        public TResult Result
        {
            get
            {
                _ranToCompletionEvent.WaitOne();

                return _result;
            }
            protected set
            {
                _result = value;

                _ranToCompletionEvent.Set();
            }
        }
        private TResult _result;

        public WorkerThreadWithResultBase()
        {
            _ranToCompletionEvent = new ManualResetEvent(false);
        }
    }
}