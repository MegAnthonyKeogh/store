using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreLib.Entities;
using StoreLib.Models;

namespace StoreLib.Interfaces
{
    public interface IStoreVmc
    {
       Task<ProductVm[]> GetProductsAsync();

       //decimal _GetPreTaxTotal(Product[] products);

       // decimal GetTaxPercentage(CarttemVm[] list, string State);

       // decimal _GetPostTaxTotal(CartItem[] list);

        Task<NewOrder> Checkout(ShoppingCartVm cart, stateTax state);
        
    }
}