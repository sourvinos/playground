using Interfaces;
using System;

namespace Implementations
{
    // Interface implementation - Write a message to the console (no dependencies)
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void LogInfo(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}
