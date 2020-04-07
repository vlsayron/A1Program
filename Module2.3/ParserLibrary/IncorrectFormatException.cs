using System;

namespace ParserLibrary
{
    public class IncorrectFormatException : Exception
    {
        public IncorrectFormatException(string message) : base(message)
        {
            StringValue = "";
        }
        public IncorrectFormatException(string message, Exception innerException) : base(message, innerException)
        {
            StringValue = "";
        }
        public IncorrectFormatException(string message, string stringValue) : base(message)
        {
            StringValue = stringValue;
        }
        public IncorrectFormatException(string message, Exception innerException, string stringValue) : base(message, innerException)
        {
            StringValue = stringValue;
        }

        public string StringValue { get; }


    }
}
