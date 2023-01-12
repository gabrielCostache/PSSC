using System;
using System.Runtime.Serialization;
[Serializable]
internal class InvalidCustomerException : Exception
{
    public InvalidCustomerException()
    {

    }
    public InvalidCustomerException(String? message) : base(message)
    {

    }

    public InvalidCustomerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
        protected InvalidCustomerException(SerializationInfo info, StreamingContext context) : base(info, context) {}
}