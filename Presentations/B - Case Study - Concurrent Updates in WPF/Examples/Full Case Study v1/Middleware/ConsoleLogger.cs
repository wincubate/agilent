using System;

namespace Middleware
{
    public class ConsoleLogger : ILogger
    {
        private readonly string _entity;

        public ConsoleLogger(string entity) => _entity = entity;

        public void LogInfo(string message) => PrintEntityMessage(message, ConsoleColor.Gray);
        public void LogError(Exception exception) => PrintEntityMessage(exception.Message, ConsoleColor.Red);

        public void LogSent(string message) => PrintEntityMessage(message, ConsoleColor.Cyan);
        public void LogReceived(string message) => PrintEntityMessage(message, ConsoleColor.Green);

        private void PrintEntityMessage(string message, ConsoleColor color)
        {
            lock (typeof(Console))
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"{DateTime.Now} - {_entity}\t - {message}");
                Console.ResetColor();
            }
        }
    }
}