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

        [Route("")]
        
        [HttpGet]
        // this should be an async await task. this is duplicated in the api shopping cart controller
        public ActionResult Index()
        {// should I put data here?
           // var orderinfo = new ReturnOrder { OrderId = OrderId }; // set the poco
           // var order = await _vmc.GetOrderAsync(orderinfo);
            return View("due to low inventory this order could not be processeed");
        }
        // GET: Checkout

        [Route("fail")]  
        [HttpGet]
        // this should be an async await task. this is duplicated in the api shopping cart controller
        public ActionResult fail()
        {// should I put data here?
            //var orderinfo = new ReturnOrder { OrderId = OrderId }; // set the poco
            //var order = await _vmc.GetOrderAsync(orderinfo);
            return View();
        }


        [Route("{OrderId}")]
        [Route("")]
        [HttpGet]
        // this should be an async await task. this is duplicated in the api shopping cart controller
        public async  Task<ActionResult> Index( int OrderId)
        {// should I put data here?
            var orderinfo = new ReturnOrder { OrderId = OrderId }; // set the poco
            var order = await _vmc.GetOrderAsync(orderinfo);
            return View(order);
        }
    }
}

