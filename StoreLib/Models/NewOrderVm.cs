using StoreLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Models
{
    public class NewOrderVm : ProductVm
    {

        public decimal Tax { get; set; }

        public List<CarttemVm> Items;
    }
}