using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektRestauracja.WebUI.Infrastructure.Abstract {
    public interface IAuthProvider {
        void Authenticate(string username);
        void SignOut();
    }
}
