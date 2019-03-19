using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreLib.Entities;
using StoreLib.Models;

namespace StoreLib.Interfaces
{
    public interface IStoreBc
    {
       Task<Product[]> GetProductsAsync();
        //decimal GetTaxPercentage();

        DateTime GetEstimateArrivalDate();

        // Product[] GetProducts();

        // decimal _GetPostTaxTotal(Product[] products);

        //  decimal _GetPreTaxTotal(Product[] products);

        //   Task<Product[]> UpdateProductsAsync();

        // Task<Order> Checkout(Order order);
        //Task<Order> Checkout(NewOrder order);
       Task <NewOrder> Checkout(NewOrder order);
    }
}
