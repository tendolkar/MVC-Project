using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InventoryMVC.Models;
using InventoryMVC.Models.ViewModels;

namespace InventoryMVC.Controllers
{
    public class ClientOrdersController : Controller
    {
        private MyDbContext _context;

        public ClientOrdersController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Update(int id)
        {
            var clientOrder = new ClientOrderViewModel()
            {
                ClientOrders = _context.TableClientOrders.Include(c=>c.Items).Include(d=>d.Clients).SingleOrDefault(c => c.id == id),
                Client = _context.TableClients.ToList(),
                Item = _context.TableItems.ToList()
            };
            if (clientOrder == null)
            {
                return HttpNotFound();

            }
            return View("ClientOrderForm", clientOrder);
        }

        public ActionResult AddOrder()
        {

            var clients = _context.TableClients.ToList();
            var items = _context.TableItems.ToList();
            var viewModel = new ClientOrderViewModel
            {
                ClientOrders = new ClientOrders { date = DateTime.Now },
                Client = clients,
                Item = items
            };
            return View("ClientOrderForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientOrders clientOrders)
        {
            var itemInDb = _context.TableItems.Single(c => c.id == clientOrders.ItemsId);
            if (!ModelState.IsValid)
            {
                var clientOrder = new ClientOrderViewModel()
                {
                    ClientOrders = clientOrders,
                    Client = _context.TableClients.ToList(),
                    Item = _context.TableItems.ToList()
                };
                return View("ClientOrderForm", clientOrder);

            }
            var clientInDb = _context.TableClients.Single(c => c.id == clientOrders.ClientsId);
            if (clientOrders.id == 0)
            {
                clientOrders.bill = clientOrders.quantity * itemInDb.sellingPrice;
                _context.TableClientOrders.Add(clientOrders);
            }

            else
            {
                var clientOrderInDb = _context.TableClientOrders.Single(c => c.id == clientOrders.id);
                itemInDb.quantity = itemInDb.quantity + clientOrderInDb.quantity;
                clientOrderInDb.ClientsId = clientOrders.ClientsId;
                clientOrderInDb.ItemsId = clientOrders.ItemsId;
                clientOrderInDb.quantity = clientOrders.quantity;
                clientOrderInDb.date = clientOrders.date;
                clientOrderInDb.status = clientOrders.status;
                clientOrderInDb.bill = clientOrders.quantity* itemInDb.sellingPrice;
            }
            if (clientOrders.status.Equals("2"))
            {
                clientInDb.balance = clientInDb.balance - clientOrders.bill;
            }
            if (!clientOrders.status.Equals("3"))
            {
                itemInDb.quantity = itemInDb.quantity - clientOrders.quantity;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "ClientOrders");

        }

        public ViewResult Index()
        {
            var clientOrder = _context.TableClientOrders.Include(c => c.Clients).Include(d=>d.Items).ToList();
            return View(clientOrder);
        }
    }
}