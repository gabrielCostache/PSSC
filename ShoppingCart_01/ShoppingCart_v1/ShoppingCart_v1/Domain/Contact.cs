using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart_v1.Domain
{
    public record Contact
    {
        private string Name { get; }
        private string PhoneNr { get; }
        private string Address { get; }

        public Contact(string name, string phoneNr, string address)
        {
            Name = name;
            PhoneNr = phoneNr;
            Address = address;
        }

        public override string ToString()
        {
            return base.ToString(); /* complete with reduntant content */
        }

    }

}
