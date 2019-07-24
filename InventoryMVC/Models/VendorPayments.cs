using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models
{
    public class VendorPayments
    {
        public int id { get; set; }
        [Required]
        public int amountPaid { get; set; }
        [Required]
        public DateTime datePaid { get; set; }


        [Required]
        public int VendorsId { get; set; }
        public Vendors Vendors { get; set; }
    }
}