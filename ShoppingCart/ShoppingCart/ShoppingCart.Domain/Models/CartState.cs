using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Declararea starilor cosului de cumparaturi */

namespace ShoppingCart.Domain.Models
{
    [AsChoice]
    public static partial class CartState
    {
        public interface ICartState
        {
            //void Match(Func<object, CartStateUnvalidated> whenUnvalidatedCartState, Func<object, object> whenPublishedCartState, Func<object, object> whenInvalidatedCartState, Func<object, ICartState> whenValidatedCartState);
        }

        public record CartStateEmpty: ICartState
        {
            public CartStateEmpty(IReadOnlyCollection<ClientStateUnvalidated> CartState)
            {
                cartState = (IReadOnlyCollection<CartStateEmpty>?)CartState;
            }
            public IReadOnlyCollection<CartStateEmpty> cartState { get; }
        }
        public record CartStateUnvalidated(IReadOnlyCollection<ClientStateUnvalidated> CartState) : ICartState;
        public record CartStateValidated(IReadOnlyCollection<ClientStateValidated> CartState) : ICartState;
        public record CartStatePaid(IReadOnlyCollection<ClientStateValidated> CartState, DateTime PublishedDate) : ICartState;

        //public IReadOnlyCollection<CartComputation> cartState { get; }
        //public DateTime PublishedDate { get; }
       // public string Csv { get; }
    }
}
