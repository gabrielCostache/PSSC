using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Models
{
    public record Quantity
    {
        public int Value { get; }

        public Quantity (int value)
        {
            if (value > 0)
            {
                Value = value;
            }
            else
            {
                throw new InvalidClientException($"{value:#} is not a valid quantity");
            }
        }
        public override string ToString()
        {
            return $"{Value:#}";
        }
    }
}
