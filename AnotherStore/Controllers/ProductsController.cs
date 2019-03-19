
using StoreLib.Models;
using System.Threading.Tasks;
using StoreLib.Interfaces;
using StoreLib;
using System.Web.Mvc;

namespace AnotherStore.Controllers
{
   [RoutePrefix("")]
    public class ProductsController : Controller
    {
        private static IStoreVmc _vmc = ObjectFactory.Create<IStoreVmc>();

        // GET: /Products/
        [Route("")]
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            ProductVm[] products = await _vmc.GetProductsAsync();
            return View(products);
        }

      
    }
}