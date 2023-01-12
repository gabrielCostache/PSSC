using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public record UnvalidatedProducts(string inventoryNr, string ProductName, string stockNumber);
}