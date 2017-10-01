using ProjektRestauracja.Domain.Entities;
using ProjektRestauracja.WebUI.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace ProjektRestauracja.WebUI.Infrastructure.Concrete {
    public class FormsAuthProvider : IAuthProvider {
        public void Authenticate(string username) {
            
            FormsAuthentication.SetAuthCookie(username, false);
        }

        public void SignOut() {

            FormsAuthentication.SignOut();
        }
    }
}