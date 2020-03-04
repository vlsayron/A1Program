using System;
using CustomerContracts;

namespace CustomerBl
{
    public class Logger:ILogger
    {
        public string Log(string message)
        {
            return $"{DateTime.Now} log message: {message}";
        }

        
    }
}