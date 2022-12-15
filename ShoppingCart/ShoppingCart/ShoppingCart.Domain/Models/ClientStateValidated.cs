﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Models
{
    public record ClientStateValidated(Quantity quantity, ProductCode productCode, Address address);
}
