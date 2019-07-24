using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models
{
    public class Items
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public int quantity { get; set; }
        
        [Required]
        [ValidationModels.PriceValidation]
        public int sellingPrice { get; set; }


        public ICollection<ClientOrders> ClientOrder { get; set; }
        public ICollection<VendorOrders> VendorOrder { get; set; }
    }
}