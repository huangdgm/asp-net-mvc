using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AutomatedTellerMachine
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // The discipline of the order of MapRoute is: from most specific to most generic.
            // The system searchs from the top to the bottom and will stop searching once a matched MapRoute is found.
            // The keyword included in the curly bracket must have the same name with the parameter in the action method, which is 'Serial' here.
            routes.MapRoute(
                name: "serial number",
                url: "serial/{letterCase}",
                defaults: new { controller = "Home", action = "Serial", letterCase = "upper" }
            );

            // This MapRoute has a different url. We need to use the '/serial?letterCase=xxx' to match this MapRoute.
            //routes.MapRoute(
            //    name: "serial number 1",
            //    url: "serial",
            //    defaults: new { controller = "Home", action = "Serial" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
