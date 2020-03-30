

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;




namespace firstAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            var container = CastleConfig.GetContainer();
            var contollerActivator = new CastleControllerActivator(container);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), contollerActivator);
            // firstAPI.App_Start.NinjectWebCommon.Start();
            //DependencyResolver.SetResolver(new NinjectResolver(firstAPI.App_Start.NinjectWebCommon.CreateKernel()));



        }
        

    }
}
