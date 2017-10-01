using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektRestauracja.WebUI.Models {
    public class LoginViewModel {

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
    }
}