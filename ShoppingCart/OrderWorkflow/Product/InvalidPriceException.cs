using System;
using System.Runtime.Serialization;
[Serializable]
internal class InvalidProductNameException : Exception
{
    public InvalidProductNameException()
    {
    }
    public InvalidProductNameException(String? message) : base(message)
    {
    }
    public InvalidProductNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected InvalidProductNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
}