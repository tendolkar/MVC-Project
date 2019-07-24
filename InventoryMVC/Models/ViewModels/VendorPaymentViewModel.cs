using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ViewModels
{
    public class VendorPaymentViewModel
    {
        public IEnumerable<Vendors> Vendor { get; set; }
        public VendorPayments VendorPayments { get; set; }
    }
}