using System;
using LanguageExt;
using System.Threading.Tasks;
using static ShoppingCart.OrdersPublishedEvent;
using static ShoppingCart.PublishOrdersCommand;
using static ShoppingCart.OrdersOperations;
using static ShoppingCart.Order;
namespace ShoppingCart
{
    public class PublishGradeWorkflow
    {
        public async Task<IOrdersPublishedEvent> ExecuteAsync(PublishOrdersCommand command, Func<Customer, TryAsync<bool>> checkCustomer)
        {
            UnvalidatedOrders unvalidatedOrders = new UnvalidatedOrders(command.InputOrders);
            IOrders orders = await ValidateOrders(checkCustomer, unvalidatedOrders);
            orders = PublishOrders(orders);

            return orders.Match(
                    whenUnvalidatedOrders: unvalidatedGrades => new OrdersPublishFaildEvent("Unexpected unvalidated state") as IOrdersPublishedEvent,
                    whenInvalidatedOrders: invalidOrders => new OrdersPublishFaildEvent(invalidOrders.Reason),
                    whenValidatedOrders: validatedOrders => new OrdersPublishFaildEvent("Unexpected validated state"),
                    whenPublishedOrders: publishedOrders => new OrdersPublishScucceededEvent("Published", publishedOrders.PublishedDate)
                );       
        }
    }
}