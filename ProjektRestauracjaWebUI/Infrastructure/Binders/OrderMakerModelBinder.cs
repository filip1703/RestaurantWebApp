using ProjektRestauracja.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektRestauracja.WebUI.Infrastructure.Binders {
    public class OrderMakerModelBinder : IModelBinder {

        private const string sessionKey = "OrderMaker";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {

            OrderMaker model = null;
            if (controllerContext.HttpContext.Session != null) {
                model = (OrderMaker)controllerContext.HttpContext.Session[sessionKey];
            }
            if (model == null) {
                model = new OrderMaker();
                if (controllerContext.HttpContext.Session != null) {

                    controllerContext.HttpContext.Session[sessionKey] = model;
                }
                    
            }
            return model;
        }
    }
}