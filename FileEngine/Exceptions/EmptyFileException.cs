using System;

namespace FileEngine.Exceptions
{
    public class EmptyFileException : Exception 
    {
        public EmptyFileException(string message) : base(message) { }
        public EmptyFileException(string message, Exception innerException) : base(message, innerException) { }
    }
}
