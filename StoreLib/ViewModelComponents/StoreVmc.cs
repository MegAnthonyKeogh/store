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
            foreach (var p in cart.Items)
            {
                var individualProduct = new OrderProduct()
                {
                    ProductID = p.ProductID,
                    QuantityToBuy= p.Quantity,
                    Price = p.Price,
                    Name = p.Name,
                    //Image = p.Image
                    

                };
                Order.Items.Add(individualProduct);
            }

            NewOrder rderReturntoClient =  await Store.Checkout( Order);
            return rderReturntoClient;
        }

        public async Task<ReturnOrderVm> GetOrderAsync(ReturnOrder Order)
        { 
            var order = await Store.GetOrderAsync(Order);
            return _mapOrder(order);
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
                    Image = p.Image
                };
                output.Add(vm);
            }

            return output.ToArray();
        }

        private static ReturnOrderVm _mapOrder(ReturnOrder Order)
        {
            var order = new ReturnOrderVm()
            {
                Items = new List<CarttemVm>(),
                OrderId = Order.OrderId,
                Tax = Order.Tax
            };
            foreach (var p in Order.Items)
            {
                var individualProduct = new CarttemVm()
                {
                    ProductID = p.ProductID,
                    Quantity = p.QuantityToBuy,
                    Name = p.Name,
                    Price = p.Price
                };
                order.Items.Add(individualProduct);
            }
            return order;
        }
    }
}

