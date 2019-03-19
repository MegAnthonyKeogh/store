using System.Collections.Generic;

namespace StoreLib.Entities
{
    public class NewOrder
    {
        public decimal Tax { get; set; }
        public List<OrderProduct> Items { get; set; }
    }
}
