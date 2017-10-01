using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjektRestauracjaWebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "{kind}", new { controller = "Home", action = "Menu" });

            routes.MapRoute(null, "", new { controller = "Home", action = "StartPage" });



            //routes.MapRoute(null, "{controller}/{category}", new { action = "List" });
            /*
            routes.MapRoute(
               null, "{controller}/{action}/{kind}"
            );
            */
            routes.MapRoute(
               null, "{controller}/{action}"
            );

            
        }
    }
}
