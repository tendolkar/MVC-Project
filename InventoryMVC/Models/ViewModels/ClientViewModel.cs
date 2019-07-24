using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ViewModels
{
    public class ClientViewModel
    {
        public Clients Client { get; set; }
        public IEnumerable<ClientPayments> ClientPayments { get; set; }
        public IEnumerable<ClientOrders> ClientOrders { get; set; }
    }
}