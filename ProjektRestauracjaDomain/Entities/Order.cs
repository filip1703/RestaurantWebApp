using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRestauracja.Domain.Entities
{
    //[Table("Table")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OrderNr { get; set; }
        public int ClientID { get; set; }
        public int WaiterID { get; set; }
        public decimal OrderValue { get; set; }

        public bool Realization { get; set; }

        public int? TableNr { get; set; }
        public DateTime OrderDateTime { get; set; }



    }
}