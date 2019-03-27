using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Models
{
    public class ReturnOrderVm
    {
        public int OrderId { get; set; }
        public decimal Tax { get; set; }
        public List<CarttemVm> Items { get; set; }
    }
}