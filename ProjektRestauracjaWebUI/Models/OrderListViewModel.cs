using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektRestauracja.Domain.Entities;


namespace ProjektRestauracja.WebUI.Models {
    public class OrderListViewModel {

        
        public IEnumerable<OrderViewModel> Orders;
        public IEnumerable<Product> Products;
    }

    public class OrderViewModel {

        
        public Order _Order { get; set; }

        public IEnumerable<OrderPosition> Positions { get; set; }
    }
}