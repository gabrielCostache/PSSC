using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    [AsChoice]
    public static partial class Order
    {
        public interface IOrders { }

        public record UnvalidatedOrders: IOrders
        {
            public UnvalidatedOrders(IReadOnlyCollection<UnvalidatedOrder> orderList)
            {
                OrderList = orderList;
            }
            public IReadOnlyCollection<UnvalidatedOrder> OrderList { get; }
        }

        public record InvalidatedOrders : IOrders
        {
            internal InvalidatedOrders(IReadOnlyCollection<UnvalidatedOrder> orderList, string reason)
            {
                OrderList = orderList;
                Reason = reason;
            }
            public IReadOnlyCollection<UnvalidatedOrder> OrderList { get; }
            public string Reason { get; }
        }

        public record ValidatedOrders(IReadOnlyCollection<ValidatedOrder> OrderList) : IOrders;

        public record PublishedOrders: IOrders
        {
            internal PublishedOrders(IReadOnlyCollection<ValidatedOrder> orderList, DateTime publishedDate)
            {
                OrderList = orderList;
                PublishedDate = publishedDate;
                
            }

            public IReadOnlyCollection<ValidatedOrder> OrderList { get; }
            public DateTime PublishedDate { get; }
            
        }
		
    }
}