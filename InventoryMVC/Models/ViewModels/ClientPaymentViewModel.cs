using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ViewModels
{
    public class ClientPaymentViewModel
    {
        public IEnumerable<Clients> Client { get; set; }
        public ClientPayments ClientPayments { get; set; }
    }
}