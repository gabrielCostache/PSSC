using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Models
{
    public record ProductCode
    {
        public string Value { get; }

        public ProductCode(string value)
        {
            if (value != null)
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
    }
}
