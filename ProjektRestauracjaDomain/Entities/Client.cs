using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRestauracja.Domain.Entities
{
    
    [Table("Clients")]
    public class Client : Person
    {

        public int? NrOfVisits { get; set; } = 0;

        


    }
}