using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRestauracja.Domain.Entities
{
    public class Booking
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookingNr { get; set; }

        public int TableNr { get; set; }
        

        public int ClientID { get; set; }

        public DateTime BookingDate { get; set; }
        public DateTime VisitDateTime { get; set; }
        public bool Realization { get; set; }

        
    
    }
}