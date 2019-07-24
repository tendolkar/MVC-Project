using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ViewModels
{
    public class VendorOrderViewModel
    {
        public IEnumerable<Vendors> Vendor { get; set; }
        public IEnumerable<Items> Item { get; set; }
        public VendorOrders VendorOrders { get; set; }
    }
}