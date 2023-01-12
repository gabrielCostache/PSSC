using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static LanguageExt.Prelude;

namespace ShoppingCart
{
        public record ProductName
        {
            public string ProductNameValue { get; }
            private static readonly Regex ValidPattern = new("^[a-z]+$"); /* only small characters */
            private ProductName(string value)
            {
                if (IsValid(value))
                {
                    ProductNameValue = value;
                }
                else
                {
                    throw new InvalidProductNameException($"{ProductNameValue} is an invalid name!");
                }
            }
            private static bool IsValid(string stringValue) => ValidPattern.IsMatch(stringValue);
            public static Option<ProductName> TryParse(string stringValue)
            {
                if (IsValid(stringValue))
                {
                    return Some<ProductName>(new(stringValue));
                }
                else
                {
                    return None;
                }
            }
        }
}