
using StoreLib.Models;
using System.Threading.Tasks;
using StoreLib.Interfaces;
using StoreLib;
using System.Web.Http;

namespace AnotherStore.Controllers.Api
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private static IStoreVmc _vmc = ObjectFactory.Create<IStoreVmc>();

        // GET: /Products/
        [Route("")]
        [HttpGet]
        public async Task<IHttpActionResult> Index()
        {
            ProductVm[] products = await _vmc.GetProductsAsync();
            return Ok(products);
        }


    }
}