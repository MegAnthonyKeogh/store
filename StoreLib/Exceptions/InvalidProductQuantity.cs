using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreLib.Entities;

namespace StoreLib.Exceptions
{
    public class InvalidProductQuantity : Exception
    {
        public OrderProduct Product { get; private set; }

        public InvalidProductQuantity(OrderProduct p)
            : base($"Customer cannot purchase {p.QuantityToBuy} {p.Name}(s). ")
        {
            Product = p;
        }

    }
}