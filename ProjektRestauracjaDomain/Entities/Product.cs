using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektRestauracja.Domain.Entities {
    public class Product {
        public int ProductID { get; set; }

        public int? EmployeeID { get; set; }

        public bool Accessibility { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Kind? Kind { get; set; }
    }

    public enum Kind { Pierwsze_danie=1,Drugie_danie,Dodatek,Napoj_alkoholowy,Napoj_zimny,Napoj_goracy,Sniadanie} 
    
}