using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace firstAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API configuration and services

            // Web API routes
            config.EnableCors(new EnableCorsAttribute("http://localhost:4200", "*", "*"));
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //var corsAttribute = new EnableCorsAttribute("http://localhost:80", "*", "*");
            //config.EnableCors(corsAttribute);
            ////config.AddFiveLevelsOfMediaType();
            //config.MapHttpAttributeRoutes();
            //config.Filters.Add(new AuthorizeAttribute());

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

        }
    }
}
