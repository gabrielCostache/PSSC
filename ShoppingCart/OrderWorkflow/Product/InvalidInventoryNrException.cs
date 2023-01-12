using System;
using System.Runtime.Serialization;
[Serializable]
internal class InvalidInventoryNrException : Exception
{
    public InvalidInventoryNrException()
    {

    }
    public InvalidInventoryNrException(String? message) : base(message)
    {
    }

    public InvalidInventoryNrException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidInventoryNrException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
}