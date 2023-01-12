using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;

namespace ShoppingCart
{
    public record Customer
    {
        public string CustomerName { get; }
        private static readonly Regex ValidPattern = new("^[a-z]+$"); /* only small characters */
        private Customer(string value)
        {
            if(IsValid(value))
            {
                CustomerName = value;
            }
            else
            {
                throw new InvalidProductNameException($"{CustomerName} is an invalid name!");
            }

        }
        private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);
        public static Option<Customer> TryParse(string stringValue)
            {
                if (IsValid(stringValue))
                {
                    return Some<Customer>(new(stringValue));
                }
                else
                {
                    return None;
                }
            }
    }
}