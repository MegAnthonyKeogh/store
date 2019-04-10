using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Models
{
    public class ProductVm
    {   
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuanityOnHand { get; set; }

        public string Image { get; set; }
     

    }
}