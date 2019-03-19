using StoreLib.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreLib.Interfaces;
using StoreLib.Models;


namespace AnotherStore.Controllers
{
    [RoutePrefix("cart")]
    public class CartController : Controller

    {
        //private static IStoreVmc _vmc = ObjectFactory.Create<IStoreVmc>();

        // GET: Cart
        [Route("")]
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }

        



    }
}