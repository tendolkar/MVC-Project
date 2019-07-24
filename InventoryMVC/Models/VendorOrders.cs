using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models
{
    public class VendorOrders
    {
        public int id { get; set; }
        [Required]
        public int quantity { get; set; }
        [Required]
        [ValidationModels.VendorBillValidation]
        public int bill { get; set; }
        [Required]
        public DateTime date { get; set; }


        [Required]
        public int ItemsId { get; set; }
        public Items Items { get; set; }

        [Required]
        public int VendorsId { get; set; }
        public Vendors Vendors { get; set; }
    }
}