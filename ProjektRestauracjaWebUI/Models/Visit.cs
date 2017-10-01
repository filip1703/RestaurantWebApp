using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektRestauracja.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjektRestauracja.WebUI.Models {
    public class Visit {

        public Table VisitTable { get; set; }

        //public Location TableLocation { get; set; }
        [Required]
        [Display(Name = "Data i godzina wizyty")]
        public DateTime VisitDateTime { get; set; }

        
    }
}