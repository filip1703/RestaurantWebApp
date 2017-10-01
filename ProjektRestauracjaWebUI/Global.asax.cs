using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ProjektRestauracja.Domain.Concrete;
using ProjektRestauracja.WebUI.Models;
using ProjektRestauracja.WebUI.Infrastructure.Binders;

namespace ProjektRestauracjaWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer<EFDbContext>(null);
            ModelBinders.Binders.Add(typeof(OrderMaker), new OrderMakerModelBinder());
        }
    }
}
