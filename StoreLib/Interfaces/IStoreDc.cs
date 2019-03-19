using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreLib.Entities;

namespace StoreLib.Interfaces
{
    public interface IStoreDc
    {
        Task<Product[]> GetProductsAsync();
       // Task<Product[]> UpdateProductsAsync();
        

        Task<Order> InsertOrderId(NewOrder order);

        
        Task<Order> Checkout(NewOrder order);
    }
}
