using System;

namespace FileEngine.Exceptions
{
    public class InvalidPropertyNameException : Exception
    {
        public InvalidPropertyNameException(string message) : base(message) { }
        public InvalidPropertyNameException(string message, Exception innerException) : base(message, innerException) { }
    }
}
