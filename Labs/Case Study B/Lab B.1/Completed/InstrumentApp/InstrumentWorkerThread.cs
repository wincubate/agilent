using Instrument.Contract;
using Middleware;
using System;
using System.Threading;

namespace InstrumentApp
{
    class InstrumentWorkerThread : WorkerThreadBase<Instrument>
    {
        private readonly ILogger _logger;

        public InstrumentWorkerThread(
            ILogger logger
        )
        {
            _logger = logger;
        }

        protected async override void Work(Instrument instrument)
        {
            foreach (ReagentUpdate reagentUpdate in instrument.Draw())
            {
                try
                {
                    using (var client = new InstrumentClient())
                    {
                        await client.UpdateAsync(reagentUpdate);
                    }
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception);
                }

                if( IsStopPending )
                {
                    break;
                }

                Thread.Sleep(instrument.UpdateInterval);
            }
        }
    }
}
