using System.Collections.Generic;

namespace StoreLib.Entities
{
    public class NewOrder
    {   public int OrderId { get; }
        public decimal Tax { get; set; }
        
        public List<OrderProduct> Items { get; set; }
    }
}
