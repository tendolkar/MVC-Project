using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryMVC.Models
{
    public class ClientOrders
    {
        public int id { get; set; }

        [Required]
        public int bill { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        [ValidationModels.ClientOrderQuantity]
        public int quantity { get; set; }


        [Required]
        public int ClientsId { get; set; }
        public Clients Clients { get; set; }

        [Required]
        public int ItemsId { get; set; }
        public Items Items { get; set; }
    }
}