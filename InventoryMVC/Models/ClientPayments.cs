using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models
{
    public class ClientPayments
    {
        public int id { get; set; }
        [Required]
        public int amountPaid { get; set; }
        [Required]
        public DateTime datePaid { get; set; }


        [Required]
        public int ClientsId { get; set; }
        public Clients Clients { get; set; }
    }
}