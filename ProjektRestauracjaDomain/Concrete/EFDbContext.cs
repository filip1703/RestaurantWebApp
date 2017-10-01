using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjektRestauracja.Domain.Entities;

namespace ProjektRestauracja.Domain.Concrete
{
    public class EFDbContext : DbContext {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<OrderPosition> OrderPositions { get; set; }

        public DbSet<Client> Clients { get; set; }


    }
}