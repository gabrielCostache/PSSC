using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    [AsChoice]
    public static partial class OrdersPublishedEvent
    {
        public interface IOrdersPublishedEvent { }
        public record OrdersPublishScucceededEvent : IOrdersPublishedEvent 
        {
            public string Csv{ get;}
            public DateTime PublishedDate { get; }
            internal OrdersPublishScucceededEvent(string csv, DateTime publishedDate)
            {
                Csv = csv;
                PublishedDate = publishedDate;
            }
        }
        public record OrdersPublishFaildEvent : IOrdersPublishedEvent 
        {
            public string Reason { get; }

            internal OrdersPublishFaildEvent(string reason)
            {
                Reason = reason;
            }
        }
    }
}