using StoreLib;
using StoreLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using StoreLib.Models;
using StoreLib.Entities;

namespace AnotherStore.Controllers.Api
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private static IStoreVmc _vmc = ObjectFactory.Create<IStoreVmc>();

        [HttpGet] // took out orderId to see if this works
        [Route("getorder/{OrderId}")]
        public async Task<IHttpActionResult> GetOrderAsync(int OrderId)
        {
            var orderinfo = new ReturnOrder { OrderId = OrderId };
            var order = await _vmc.GetOrderAsync(orderinfo);
            return Ok(order);
        } 
    }
}
