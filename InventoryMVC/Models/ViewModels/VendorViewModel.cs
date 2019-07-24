using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ViewModels
{
    public class VendorViewModel
    {
        public Vendors Vendor { get; set; }
        public IEnumerable<VendorPayments> VendorPayments { get; set; }
        public IEnumerable<VendorOrders> VendorOrders { get; set; }
    }
}