using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using AnotherStore.App_Start;
using StoreLib.BusinessComponents;
using StoreLib.Data;
using StoreLib.Models;
using StoreLib.ViewModelComponents;
using StoreLib.Web;

namespace AnotherStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // set up factory
            StoreLib.ObjectFactory.Register<StoreLib.Interfaces.IStoreVmc, StoreVmc>(new StoreVmc());
            StoreLib.ObjectFactory.Register<StoreLib.Interfaces.IStoreDc, StoreDc>(new StoreDc());

            var deStore = new StoreBC();
            deStore.TaxPercentage = 0;
           
            var paStore = new StoreBC();
            paStore.TaxPercentage = 6;
            var njStore = new StoreBC();
            njStore.TaxPercentage = 7;
            var mdStore = new StoreBC();
            mdStore.TaxPercentage = 6;

            StoreLib.ObjectFactory.Register<StoreLib.Interfaces.IStoreBc, StoreBC>(deStore, "DE");
            StoreLib.ObjectFactory.Register<StoreLib.Interfaces.IStoreBc, StoreBC>(paStore, "PA");
            StoreLib.ObjectFactory.Register<StoreLib.Interfaces.IStoreBc, StoreBC>(njStore, "NJ");
            StoreLib.ObjectFactory.Register<StoreLib.Interfaces.IStoreBc, StoreBC>(mdStore, "MD");
            StoreLib.ObjectFactory.Register<StoreLib.Interfaces.IStoreBc, StoreBC>(new StoreBC());
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            var cart = new ShoppingCartVm
            {
                Items = new List<CarttemVm>()
            };
            ShoppingCartHelper.SetCart(System.Web.HttpContext.Current, cart);
        }

        protected void Application_PostAuthorizeRequest()
        {
            HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
        }
    }
}
