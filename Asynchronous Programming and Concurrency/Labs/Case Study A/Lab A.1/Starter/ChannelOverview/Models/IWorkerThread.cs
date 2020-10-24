using System;

namespace ChannelOverview.Models
{
    public interface IWorkerThread<TInput> : IDisposable
    {
        void Start(TInput input);
        void Kill();
    }
}
