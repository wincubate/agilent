using System;

namespace Middleware
{
    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(Exception exception);

        void LogSent(string message);
        void LogReceived(string message);
    }
}
