using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StoreLib.Entities
{
    public class Order : NewOrder
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}