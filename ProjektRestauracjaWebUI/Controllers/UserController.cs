using ProjektRestauracja.Domain.Abstract;
using ProjektRestauracja.Domain.Entities;
using ProjektRestauracja.WebUI.Infrastructure.Abstract;
using ProjektRestauracja.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektRestauracja.WebUI.Controllers
{
    public class UserController : Controller {
        IAuthProvider authProvider;
        IGenericRepository<Client> clientRepository; 

        public UserController(IAuthProvider auth, IGenericRepository<Client> repo) {
            authProvider = auth;
            clientRepository = repo;
        }

        public ViewResult Login() {
            return View();
        }

        public ViewResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl) {
            
            if (ModelState.IsValid) {

                string pass = Helpers.SHA1Helper.Encode(model.Password);

                IEnumerable<Client> validClients = clientRepository.Entities.Where(x => x.Email == model.Email && x.Password == pass).Select(x => x);

                if (validClients.Any()) {
                    authProvider.Authenticate(model.Email);
                    return Redirect(returnUrl ?? Url.Action("StartPage", "Home"));
                }
                else {
                    ModelState.AddModelError("", "Nieprawidłowa nazwa użytkownika lub hasło.");
                    return View();
                }
            }
            else {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Register(Client model, string returnUrl) {

            if (ModelState.IsValid) {

                if (clientRepository.Entities.Where(x => x.Email == model.Email).Any()) {
                    ModelState.AddModelError("", "Osoba o takim samym adresie e-mail znajduje się już w bazie");
                    return View();
                }

                string pass = Helpers.SHA1Helper.Encode(model.Password);

                model.RegisterDate = DateTime.Now;
                model.Password = pass;

                clientRepository.SaveEntity(model);

                return Redirect(returnUrl ?? Url.Action("StartPage", "Home"));
            }

            else {
                return View();
            }
        }
        

        public RedirectToRouteResult Logout () {
            authProvider.SignOut();
            return RedirectToAction("StartPage", "Home");
        }
    }   
}