using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public record InventoryNr
    {
        public decimal InventoryNrValue { get; }
        public InventoryNr(decimal value)
        {
            if(InventoryNrValue >0)
            {
                InventoryNrValue = value;
            }
            else
            {
                throw new InvalidInventoryNrException($"{InventoryNrValue:0} is an invalid inventory number value");
            }
        }
    }
}