using System;

namespace FileEngine.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        public PropertyNotFoundException(string message) : base(message) { }
        public PropertyNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
