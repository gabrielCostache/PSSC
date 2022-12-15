using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Models
{
    public record ClientName
    {
        public string Value { get; }

        private ClientName(string value)
        {
            if (value!= null)
            {
                Value = value;
            }
            else
            {
                throw new InvalidClientException("");
            }
        }
        public override string ToString()
        {
            return Value;
        }

        public static bool TryParse(string stringValue, out ClientName clientName)
        {
            bool isValid = false;
            clientName = null;

            if (stringValue != null)
            {
                isValid = true;
                clientName = new(stringValue);
            }

            return isValid;
        }
    }
}
