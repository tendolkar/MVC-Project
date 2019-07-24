using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InventoryMVC.Models
{
    public class Clients
    {
        
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        [Phone]
        public string contact { get; set; }
        
        [Required]
        [ValidationModels.ClientBalValidation]
        public double balance { get; set; }



        public ICollection<ClientOrders> ClientOrder { get; set; }
        public ICollection<ClientPayments> ClientPayment { get; set; }
    }
}