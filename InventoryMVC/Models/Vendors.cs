using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models
{
    public class Vendors
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        [Phone]
        public string contact { get; set; }

        [Required]
        [ValidationModels.VendorBalValidation]
        public int balance { get; set; }
        public ICollection<VendorOrders> VendorOrder { get; set; }
        public ICollection<VendorPayments> VendorPayment { get; set; }
      
    }
}