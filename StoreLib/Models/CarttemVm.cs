﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Models
{
    public class CarttemVm : ProductVm
    {
        
        public int Quantity { get; set; }
        public double Total { get; set; }

        public string Image { get; set; }


    }
}