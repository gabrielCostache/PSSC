using ShoppingCart;
using System;
using System.Collections.Generic;
using static ShoppingCart.Products;
using static ShoppingCart.Order;
using System.Text.RegularExpressions;
using static ShoppingCart.OrdersOperations;
using static ShoppingCart.PublishOrdersCommand;
using LanguageExt;
using static LanguageExt.Prelude;
using System.Threading.Tasks;
using static System.Object;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Formats.Asn1;
using System.Text.Json;

namespace ShoppingCart
{
    public class DataStructure
    {
        public string name { get; set; }
        public int quantity { get; set; }
    }
    class Program
    {
        const string filePath = @"D:\An 4\SEM 1\PSSC-Proiectarea sistemelor software complexe\Proiect_final\ShoppingCart\ShoppingCart\Write.json";
        static async Task Main(string[] args)
        {
            var deserialized = Deserialize(@"D:\An 4\SEM 1\PSSC-Proiectarea sistemelor software complexe\Proiect_final\ShoppingCart\ShoppingCart\infoStock.json");

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized.ToString());
            List<DataStructure> deserializedProduct = JsonConvert.DeserializeObject<List<DataStructure>>(deserialized.ToString());
            foreach (var x in deserializedProduct)
            {
                Console.WriteLine(x.name);
                Console.WriteLine(x.quantity);
                x.quantity -= 1;
            }
            Serialize(deserializedProduct);

            /**********************************************************/
            var listOfOrders = ReadListOfOrders();
            UnvalidatedOrders unvOrders = new(listOfOrders);
            printListOfOrders(unvOrders);
            PublishOrdersCommand command = new(listOfOrders);
            PublishGradeWorkflow workflow = new();
            var result = await workflow.ExecuteAsync(command, CheckCustomer);
            result.Match(
                    whenOrdersPublishFaildEvent: @event =>
                    {
                        Console.WriteLine($"Publish failed: {@event.Reason}");
                        return @event;
                    },
                    whenOrdersPublishScucceededEvent: @event =>
                    {
                        Console.WriteLine($"Publish succeeded.");
                        Console.WriteLine(@event.Csv);
                        return @event;
                    }
                );
        }
        private static List<UnvalidatedOrder> ReadListOfOrders()
        {
            List<UnvalidatedOrder> listOfOrders = new();
            do
            {
                var customer = ReadValue("Customer name: ");
                if (string.IsNullOrEmpty(customer))
                {
                    break;
                }
                var listOfProducts = ReadListOfProducts().ToList<UnvalidatedProducts>();
                listOfOrders.Add(new(customer, listOfProducts));
            } while (true);
            return listOfOrders;
        }
        private static List<UnvalidatedProducts> ReadListOfProducts()
        {
            List<UnvalidatedProducts> listOfProducts = new();
            do
            {
                var inventoryNr = ReadValue("inventoryNr: ");
                if (string.IsNullOrEmpty(inventoryNr))
                {
                    break;
                }
                var ProductName = ReadValue("ProductName: ");

                if (string.IsNullOrEmpty(ProductName))
                {
                    break;
                }
                var stockNumber = ReadValue("stockNumber: ");

                if (string.IsNullOrEmpty(stockNumber))
                {
                    break;
                }
                listOfProducts.Add(new(inventoryNr, ProductName, stockNumber));
            } while (true);
            return listOfProducts;
        }
        private static string? ReadValue(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine();
        }
        static void printListOfOrders(UnvalidatedOrders unvOrd)
        {
            foreach (var order in unvOrd.OrderList)
            {
                Console.WriteLine("Customer: " + order.customer);
                foreach (var product in order.unvalidatedProducts)
                {
                    Console.WriteLine(product.inventoryNr + ", " + product.ProductName + ", " + product.stockNumber);
                }
            }
        }
        private static TryAsync<bool> CheckCustomer(Customer customer)
        {
            Func<Task<bool>> func = async () =>
            {
                //HttpClient client = new HttpClient();

                //var response = await client.PostAsync($"www.university.com/checkRegistrationNumber?number={student.Value}", new StringContent(""));

                //response.EnsureSuccessStatusCode(); //200

                return true;
            };
            return TryAsync(func);
        }
        public static object Deserialize(string path)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();

            using (var sw = new StreamReader(path))
            using (var reader = new JsonTextReader(sw))
            {
                return serializer.Deserialize(reader);
            }
        }
        public static void Serialize(object obj)
        {
            var serializer = new Newtonsoft.Json.JsonSerializer();

            using (var sw = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }
    }
}
