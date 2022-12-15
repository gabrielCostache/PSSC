using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Models
{
        public record Address
        {
            public string Value { get; }

            public Address(string value)
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
