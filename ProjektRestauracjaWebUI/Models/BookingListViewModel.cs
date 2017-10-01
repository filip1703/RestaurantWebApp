using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektRestauracja.Domain.Entities;

namespace ProjektRestauracja.WebUI.Models {
    public class BookingListViewModel {
        public IEnumerable<Booking> Bookings { get; set; }
        public IEnumerable<Table> Tables { get; set; }
    }
}