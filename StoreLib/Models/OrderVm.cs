using StoreLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Models
{
    public class OrderVm : NewOrder
    {
        public int OrderId { get; set; }

        public float TaxRate { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual NewOrder Order { get; set; }
        
    }
}