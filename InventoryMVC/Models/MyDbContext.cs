using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryMVC.Models;
using System.Data.Entity;

namespace InventoryMVC.Models
{
    public class MyDbContext:DbContext
    {

        public DbSet<Clients> TableClients { get; set; }
        public DbSet<Vendors> TableVendors { get; set; }
        public DbSet<Items> TableItems { get; set; }
        public DbSet<VendorOrders> TableVendorOrders { get; set; }
        public DbSet<ClientOrders> TableClientOrders { get; set; }
        public DbSet<VendorPayments> TableVendorPayments { get; set; }
        public DbSet<ClientPayments> TableClientPayments { get; set; }

    }
}