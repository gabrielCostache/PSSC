using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Models
{
        public record CartComputation(ClientName clientName, ProductCode productCode, Quantity quantity, Address address);
}
