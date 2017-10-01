using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektRestauracja.Domain.Entities {
    public class OrderPosition {
        
        [Key,Column(Order = 1)]
        public int OrderNr { get; set; }
        [Key,Column(Order = 2)]
        public int PositionNr { get; set; }
        public int ProductID { get; set; }

        public int Quantity { get; set; }
    }
}