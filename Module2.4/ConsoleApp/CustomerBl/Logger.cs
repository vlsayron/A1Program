using System;
using ConsoleApp.Contracts;
using CustomContainer.Attributes;

namespace ConsoleApp.CustomerBl
{
    [Export(typeof(ILogger))]
    public class Logger: ILogger
    {
        public string Log(string message)
        {
            return $"{DateTime.Now} log message: {message}";
        }

        
    }
}