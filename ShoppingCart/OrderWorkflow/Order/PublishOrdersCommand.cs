using static ShoppingCart.Order;

namespace ShoppingCart
{
    public record PublishOrdersCommand
    {
        public PublishOrdersCommand(IReadOnlyCollection<UnvalidatedOrder> inputOrders)
        {
            InputOrders = inputOrders;
        }
        public IReadOnlyCollection<UnvalidatedOrder> InputOrders { get; }
    }
}