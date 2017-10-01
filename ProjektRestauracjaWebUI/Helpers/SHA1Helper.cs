using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektRestauracja.WebUI.Helpers {
    public class SHA1Helper {

        public static string Encode(string password) {

            var hasher = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(password ?? "");
            return BitConverter.ToString(hasher.ComputeHash(combined)).ToLower().Replace("-", "");

        }
    }
}