using System;
using ShoppingCart_v1.Domain;
using CSharp.Choices;
//using static ShoppingCart_v1.Domain.Quantity;

// See https://aka.ms/new-console-template for more information


Console.WriteLine("----------------Welcome to our shopping cart----------------");
int option = 0;
var ContactList = new List<Contact>();

Console.WriteLine("1.Add contact details and products");
Console.WriteLine("2.Show orders");
Console.WriteLine("\n");
Console.WriteLine("0. Press 0 to exit");

do
{

    option = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("You have selected:" + option+" option");
    switch (option)
    {
        case 0: break;
        case 1:
            {
                    /* must be filled */
                break;
            }

        case 2:
            {
                   /* must be filled */
                break;
            }
        default:
            {
                Console.WriteLine("This option isn't configured yet!");
                break;
            }
    }

} while (option != 0);