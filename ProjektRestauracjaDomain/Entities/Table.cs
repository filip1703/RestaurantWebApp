using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRestauracja.Domain.Entities
{
    public class Table {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int TableNr { get; set; }
        
        public int Size { get; set; }

        public Location TableLocation { get; set; }

        
    }

     
     public enum Location { Middle = 1, Corner, Window }
}