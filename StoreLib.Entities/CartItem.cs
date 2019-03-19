using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace StoreLib.Entities
{
    public class CartItem : Product
    {
       
        [Key]

        public int Quantity { get; set; }

        public double Total { get; set; }

        public virtual Product Product { get; set; }

       
    }
}