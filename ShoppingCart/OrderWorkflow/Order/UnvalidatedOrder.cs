using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShoppingCart.Products;
namespace ShoppingCart
{
    public record UnvalidatedOrder(string customer, List<UnvalidatedProducts> unvalidatedProducts);
}