using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Models
{
    internal class InvalidClientException:Exception
    {
        public InvalidClientException() { }
        public InvalidClientException(string? message) : base(message) { }
        public InvalidClientException(string? message, Exception? innerException) : base(message, innerException) { }
        protected InvalidClientException(SerializationInfo info, StreamingContext context): base(info, context) { }
    }
}
