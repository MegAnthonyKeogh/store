using System;
using System.Collections.Generic;
using System.Linq;
using StoreLib.Interfaces;
using StoreLib.Web;
using System.Web.Mvc;

using StoreLib;
using StoreLib.Models;
using System.Threading.Tasks;
using StoreLib.Entities;

namespace AnotherStore.Controllers
{
    

    [RoutePrefix("checkout")]
    public class checkoutController : Controller
    {
        private static IStoreVmc _vmc = ObjectFactory.Create<IStoreVmc>();
        // GET: Checkout

        [Route("")]
        [HttpGet]
        // this should be an async await task. this is duplicated in the api shopping cart controller
        public   ActionResult Index()
        {
           //var cart = ShoppingCartHelper.GetCart(System.Web.HttpContext.Current);
           // var order = await _vmc.Checkout();
            return View();
        }
    }
}

