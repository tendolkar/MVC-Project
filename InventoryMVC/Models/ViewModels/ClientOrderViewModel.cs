using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ViewModels
{
    public class ClientOrderViewModel
    {
        public IEnumerable<Clients> Client { get; set; }
        public IEnumerable<Items> Item { get; set; }
        public ClientOrders ClientOrders { get; set; }
    }
}