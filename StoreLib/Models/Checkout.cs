using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Models
{
    public class Checkout 
    {
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public string State { get; set; }

        public List<ProductVm> Items { get; set; }

    }
}