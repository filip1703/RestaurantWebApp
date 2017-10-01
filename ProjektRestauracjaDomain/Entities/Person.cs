using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektRestauracja.Domain.Entities
{
    public class Person
    {

        public int ID { get; set; }
        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Nazwisko")]
        public string SecondName { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Proszę podać e-mail w prawidłowym formacie")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        

    }
}