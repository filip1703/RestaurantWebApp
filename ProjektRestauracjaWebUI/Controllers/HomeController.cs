using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektRestauracja.Domain.Abstract;
using ProjektRestauracja.WebUI.Models;
using ProjektRestauracja.Domain.Entities;

namespace ProjektRestauracja.WebUI.Controllers
{
    public class HomeController : Controller {

        private IGenericRepository<Product> repository;

        public HomeController(IGenericRepository<Product> repo) {
            repository = repo;
        }

        public ViewResult StartPage() {

           

            return View();
        }

        public PartialViewResult MenuNav(bool horizontalLayout = false) {

            List<string> categories = Enum.GetNames(typeof(Kind)).ToList();

            string viewName = horizontalLayout ? "MenuNavHorizontal" : "MenuNav";

            return PartialView(viewName,categories);
        }

        

        public PartialViewResult Menu(string kind="Pierwsze_danie") {

            
            IEnumerable<Product> products = this.repository.Entities.Where(x => Enum.GetName(typeof(Kind), x.Kind) == kind);
           

            return PartialView(products); 
        }
    }
}