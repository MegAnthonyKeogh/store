using StoreLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreLib.Web
{
    public static class ShoppingCartHelper
    {
        private const string CART_SESSION_KEY = "cart";

        public static void AddProduct(HttpContext context, CarttemVm product)
        {
            var cart = GetCart(context);
            cart.Items.Add(product);
            SetCart(context, cart);
        }

        public static void RemoveProduct(HttpContext context, ProductVm product)
        {
            //var cart = GetCart(context);
            //ProductVm[] itemsToRemove = ProductVm[] cart.Items.Where(x => x.ProductID == product.ProductID);
            //cart.Items.Remove( itemsToRemove);
            //SetCart(context, cart);
        }

        public static ShoppingCartVm GetCart(HttpContext context)
        {
            return (ShoppingCartVm)context.Session[CART_SESSION_KEY];
        }

        public static void SetCart(HttpContext context, ShoppingCartVm cart)
        {
            context.Session[CART_SESSION_KEY] = cart;
        }
    }
}