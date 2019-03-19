using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Entities
{
    public class OrderProduct : Product
    {
        public int QuantityToBuy { get; set; }
    }
}