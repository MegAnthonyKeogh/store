using System;
using StoreLib.Entities;
using StoreLib.Models;
using StoreLib.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StoreLib.BusinessComponents
{
    public class StoreBC : IStoreBc
    {
        private IStoreDc _dc;

        public IStoreDc DataComponent
        {
            get => _dc ?? (_dc = ObjectFactory.Create<IStoreDc>());
            set => _dc = value;
        }

        //public async Task<Order> Checkout(Order order)
        //{
        //    Order orderReturn = await DataComponent.Checkout(order);
        //    return orderReturn;
        //}

        public decimal TaxPercentage { get; set; }

        public DateTime GetEstimateArrivalDate()
        {
            var ArrivalDate = DateTime.Today.AddDays(1);
            return ArrivalDate;
        }
        public int ShoppingCartId { get; set; }


        
        //public decimal _GetPreTaxTotal(Product[] products)
        //{
        //    decimal preTaxTotal = 0;
        //    foreach (Product p in products)
        //    {
        //        preTaxTotal += p.Price;
        //    }
        //    return preTaxTotal;
        //}


        //public decimal _GetPostTaxTotal(Product[] products)
        //{
        //    var preTax = _GetPreTaxTotal(products);
        //    var tax = preTax * TaxPercentage;
        //    var finalPrice = preTax + tax;
        //    return finalPrice;
        //}


        public async Task<Product[]> GetProductsAsync()
        {

            //throw new NotImplementedException();
            var retrieveData = await DataComponent.GetProductsAsync();
            return retrieveData;


            //get products from the data layer aka service agent
        }


        //public async Task<Order> Checkout(NewOrder order)
        //{
        //    var updatedProducts = await DataComponent.Checkout(order);
        //    return   updatedProducts;
        //}

        public async Task<NewOrder> Checkout(NewOrder order)
        {
            var updatedProducts = await DataComponent.Checkout(order);
            return updatedProducts;
        }
    }
}