using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    [AsChoice]
    public static partial class Products
    {
        public interface IProducts { }
        public record UnvalidatedProducts: IProducts
        {
            public UnvalidatedProducts(IReadOnlyCollection<UnvalidatedProducts> productList)
            {
                ProductList = productList;
            }
            public IReadOnlyCollection<UnvalidatedProducts> ProductList { get; }
        }
        public record InvalidatedProducts(IReadOnlyCollection<UnvalidatedProducts> ProductsList, string reason) : IProducts;
        public record ValidatedProducts(IReadOnlyCollection<ValidatedProducts> ProductsList) : IProducts;
        public record PublishedProducts(IReadOnlyCollection<ValidatedProducts> ProductsList, DateTime PublishedDate) : IProducts;
    }
}