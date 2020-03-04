using System;
using System.ComponentModel.Composition;
using CustomerContracts;

namespace CustomerDal.Plugins
{
    //[Export]
    public class Logger:ILogger
    {
        public string Log(string message)
        {
            return $"{DateTime.Now} log message: {message}";
        }

        
    }
}