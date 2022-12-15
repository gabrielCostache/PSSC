using System;
using System.Collections.Generic;
using static ShoppingCart.Domain.Models.CartState;
using static ShoppingCart.Domain.CartOperation;
using static ShoppingCart.Domain.Models.ClientStateValidated;
using static ShoppingCart.Domain.Models.ClientStateUnvalidated;
using ShoppingCart.Domain;
using ShoppingCart.Domain.Models;

namespace ShoppingCart
{
    class Program 
    {
        private static readonly Random random = new Random();

        static void Main(string[] args)
        {
            var listOfProducts = ReadListOfProducts().ToArray();
            CartStateUnvalidated unvalidatedCart = new(listOfProducts);
            ICartState state = ValidateCartState(unvalidatedCart);
            state.Match(
                whenCartStateUnvalidated: unvalaidatedResult => unvalidatedCart,
                whenCartStatePaid: publishedResult => publishedResult,
                whenCartStateEmpty: invalidResult => invalidResult,
                whenCartStateValidated: validatedResult => PublishCartState(validatedResult)
            );
            Console.WriteLine("Hello!");
        }

        public static List<ClientStateUnvalidated> ReadListOfProducts()
        {
                List<ClientStateUnvalidated> ListOfProducts = new();
                do
                {
                    var productCode = ReadValue("Product Code: ");
                    if (string.IsNullOrEmpty(productCode))
                    {
                        break;
                    }
                    var quantity = ReadValue("Quantity: ");
                    if (string.IsNullOrEmpty(quantity))
                    {
                        break;
                    }
                    var address = ReadValue("Address: ");
                    if (string.IsNullOrEmpty(address))
                    {
                        break;
                    }
                    ListOfProducts.Add(new(productCode, quantity, address));
                } while (true);
                return ListOfProducts;
        }
        private static ICartState ValidateCartState(CartStateUnvalidated unvalidatedCart) => random.Next(100) > 50 ?
    new CartStateUnvalidated(new List<ClientStateUnvalidated>()) : new CartStateValidated(new List<ClientStateValidated>());
        private static ICartState PublishCartState(CartStateValidated validCart) =>  new CartStatePaid(new List<ClientStateValidated>(), DateTime.Now);
        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
    
}