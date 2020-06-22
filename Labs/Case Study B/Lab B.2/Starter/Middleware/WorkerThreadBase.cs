using System;
using System.Threading;

namespace Middleware
{
    public abstract class WorkerThreadBase<TInput> : IWorkerThread<TInput>
    {
        private Thread _thread;
        protected readonly object _threadSyncObject;

        protected bool IsStopPending
        {
            get
            {
                lock (_threadSyncObject)
                {
                    return _isStopPending;
                }
            }
            set
            {
                lock (_threadSyncObject)
                {
                    _isStopPending = value;
                }
            }
        }
        private bool _isStopPending;

        public WorkerThreadBase()
        {
            _threadSyncObject = new object();
            _thread = null;
        }

        public void Start(TInput input)
        {
            if (_thread != null)
            {
                throw new InvalidOperationException("Thread already started");
            }

            _thread = new Thread(() => Work(input));
            _thread.Start();
        }

        protected abstract void Work(TInput input);

        public void Kill()
        {
            if (_thread?.IsAlive == true)
            {
                IsStopPending = true;

                _thread.Join();
            }
        }

        public void Dispose()
        {
            Kill();
        }
    }
}
