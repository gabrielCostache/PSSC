using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Choices;

namespace ShoppingCart_v1.Domain
{

    [AsChoice]
    
    public static partial class Cart
    {
        public interface ICart { }
        public record UnalidatedCart(IReadOnlyCollection<UnvalidatedCart> CartList):ICart;
        public record InvalidatedCart(IReadOnlyCollection<UnvalidatedCart> CartList, string reason):ICart;
        public record ValidatedCart(IReadOnlyCollection<ValidatedCart> CartList, string reason):ICart; 
        public record PublishCart(IReadOnlyCollection<ValidatedCart> CartList, DateTime PublishedDate):ICart;
    }


}
