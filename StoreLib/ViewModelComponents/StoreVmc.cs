using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StoreLib.Entities;
using StoreLib.Interfaces;
using StoreLib.Models;
using StoreLib.BusinessComponents;
using System.Threading.Tasks;
using StoreLib.Web;

namespace StoreLib.ViewModelComponents
{
    public class StoreVmc : IStoreVmc
    {
        private IStoreBc _store;

        public IStoreBc Store
        {
            get => _store ?? (_store = ObjectFactory.Create<IStoreBc>());
            set => _store = value;
        }


        public async Task<ProductVm[]> GetProductsAsync()
        {
            var products = await Store.GetProductsAsync();
            // var products = await _store.GetProductsAsync();
            return _mapProducts(products);
        }

        //eventually this needs to be newOrderVm
        public async Task<NewOrder> Checkout(ShoppingCartVm cart, stateTax state)
        {            
            //this is where I'm separating the order into parts so it will connect my tables in the  database.
            //after I get this up and running to the database I think i need to add an if else to see if the order is going to or from the database and not make a new order.
            var Order = new NewOrder()
            {
                Items = new List<OrderProduct>(),
                Tax = state.tax
            };
            foreach (var p in Order.Items)
            {
                var individualProduct = new OrderProduct()
                {
                    ProductID = p.ProductID,
                    QuanityOnHand = p.QuanityOnHand,
                    Price = p.Price
                    

                };
                Order.Items.Add(individualProduct);
            }

            NewOrder rderReturntoClient =  await Store.Checkout( Order);
            return rderReturntoClient;
        }



        private static ProductVm[] _mapProducts(Product[] list)
        {
            var output = new List<ProductVm>();

            foreach (var p in list)
            {
                var vm = new ProductVm
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Price = p.Price,
                    QuanityOnHand = p.QuanityOnHand,
                };
                output.Add(vm);
            }

            return output.ToArray();
        }

        

        //public decimal _GetPreTaxTotal(Product[] products)
        //{
        //    var preTax = Store._GetPreTaxTotal(products);
        //    return preTax;

        //}

        //public decimal _GetPostTaxTotal(CartItem[] list)
        //{

        //    var total = Store._GetPostTaxTotal(list);
        //    return total;
        //}

        //public decimal GetTaxPercentage(CarttemVm[] list, string State)
        //{
        //    var stateStore = ObjectFactory.Create<IStoreBc>(State);
        //    var tax = stateStore._GetPostTaxTotal(MapCartItems(list));
        //    return tax;

        //}

    }
}

