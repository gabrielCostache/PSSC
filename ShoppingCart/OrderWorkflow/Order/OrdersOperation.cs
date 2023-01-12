using static LanguageExt.Prelude;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShoppingCart.Products;
using static ShoppingCart.Order;
using static ShoppingCart.Customer;

namespace ShoppingCart
{
    public static class OrdersOperations
    {
         public static Task<IOrders> ValidateOrders(Func<Customer, TryAsync<bool>> checkStudentExists, UnvalidatedOrders orders) =>
            orders.OrderList
                      .Select(ValidateOrder(checkStudentExists))
                      .Aggregate(CreateEmptyValatedGradesList().ToAsync(), ReduceValidGrades)
                      .MatchAsync(
                            Right: validatedGrades => new ValidatedOrders(validatedGrades),
                            LeftAsync: errorMessage => Task.FromResult((IOrders)new InvalidatedOrders(orders.OrderList, errorMessage))
                      ); 
            private static Func<UnvalidatedOrder, EitherAsync<string, ValidatedOrder>> ValidateOrder(Func<Customer, TryAsync<bool>> checkCustomer) =>
                unvalidatedOrder => ValidateOrder(checkCustomer, unvalidatedOrder);

        private static EitherAsync<string, ValidatedOrder> ValidateOrder(Func<Customer, TryAsync<bool>> checkCustomer, UnvalidatedOrder unvalidatedOrder)=>
            from customer in Customer.TryParse(unvalidatedOrder.customer)
                                   .ToEitherAsync(() => $"Invalid customer name : {unvalidatedOrder.customer}")
            select new ValidatedOrder(customer, unvalidatedOrder.unvalidatedProducts );
    
    private static Either<string, List<ValidatedOrder>> CreateEmptyValatedGradesList() =>
            Right(new List<ValidatedOrder>());

        private static EitherAsync<string, List<ValidatedOrder>> ReduceValidGrades(EitherAsync<string, List<ValidatedOrder>> acc, EitherAsync<string, ValidatedOrder> next) =>
            from list in acc
            from nextOrder in next
            select list.AppendValidOrder(nextOrder);
    private static List<ValidatedOrder> AppendValidOrder(this List<ValidatedOrder> list, ValidatedOrder validOrder)
        {
            list.Add(validOrder);
            return list;
        }
        public static IOrders PublishOrders(IOrders orders) => orders.Match(
                    whenUnvalidatedOrders: unvalidatedGrades => unvalidatedGrades,
                    whenInvalidatedOrders: invalidOrders => invalidOrders,
                    whenValidatedOrders: validatedOrders => GeneratePublishedOrders(validatedOrders),
                    whenPublishedOrders: publishedOrders => publishedOrders
                );
        private static IOrders GeneratePublishedOrders(ValidatedOrders validatedOrders) => 
            new PublishedOrders(validatedOrders.OrderList, 
                                    DateTime.Now);

       
    }
    
}