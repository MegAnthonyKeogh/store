using System.Collections.Generic;
using System.Web.Http;
using StoreLib.Models;
using StoreLib.Web;
using System.Threading.Tasks;
using StoreLib;
using StoreLib.Interfaces;
using System.Web;
using StoreLib.Entities;

namespace AnotherStore.Controllers.Api
{
    [RoutePrefix("api/cart")]
    public class ShoppingCartController : ApiController
    {
        private static IStoreVmc _vmc = ObjectFactory.Create<IStoreVmc>();
       

        // GET: ShoppingCart
        [HttpPost]
        [Route("add/{productId}")]
        public IHttpActionResult AddProductToCart(int productId, [FromBody] CarttemVm product)
        {
            ShoppingCartHelper.AddProduct(System.Web.HttpContext.Current, product);
            return Ok();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetCartItems()
        {
            var items = ShoppingCartHelper.GetCart(System.Web.HttpContext.Current).Items;
            return Ok(items);
        }


        [Route("tax")]
        [HttpPost]
        public async Task<IHttpActionResult>  Index( [FromBody] stateTax state)
        {
            var Cart = ShoppingCartHelper.GetCart(HttpContext.Current);
            await _vmc.Checkout(Cart, state);
            return Ok();
        }

        

       
    }
}


    
