﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int QuanityOnHand { get; set; }
       
    }
}