using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreLib.Entities
{
    public class ReturnOrder 
    {

        public int OrderId { get; set; }
        public float Tax { get; set; }
        public List<OrderProduct> Items { get; set; }
    }
}
