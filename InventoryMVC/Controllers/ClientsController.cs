using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryMVC.Models;
using System.Data.Entity;
using InventoryMVC.Models.ViewModels;

namespace InventoryMVC.Controllers
{
    public class ClientsController : Controller
    {
        private MyDbContext _context;

        public ClientsController()
        {
            _context = new MyDbContext();
        }
        
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Clients

        public ActionResult Details(int id)
        {

            var client = _context.TableClients.SingleOrDefault(c => c.id == id);
            var clientOrders = _context.TableClientOrders.Where(c => c.ClientsId == id).Include(c=>c.Items).ToList();
            var clientPayments = _context.TableClientPayments.Where(c => c.ClientsId == id).ToList();
            var viewModel = new ClientViewModel
            {
                Client = client,
                ClientOrders = clientOrders,
                ClientPayments = clientPayments,
            };

            if (client == null)
            {
                return HttpNotFound();

            }
            return View(viewModel);
        }

        public ActionResult Update(int id)
        {

            var client = _context.TableClients.SingleOrDefault(c => c.id == id);
            if (client == null)
            {
                return HttpNotFound();

            }
            return View("ClientForm",client);
        }

        public ActionResult Delete(int id)
        {

            var client = _context.TableClients.SingleOrDefault(c => c.id == id);
            if (client == null)
            {
                return HttpNotFound();

            }
            return View(client);
        }

        public ActionResult AddClient()
        {
            var client = new Clients();
            return View("ClientForm",client);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Clients clients)
        {
            if (!ModelState.IsValid)
            {

                var client = new Clients();
                return View("ClientForm", client);

            }
            if (clients.id == 0)
            {
                _context.TableClients.Add(clients);
            }
            
            else
            {
                var clientInDb = _context.TableClients.Single(c => c.id == clients.id);
                clientInDb.name = clients.name;
                clientInDb.address = clients.address;
                clientInDb.contact = clients.contact;
                clientInDb.balance = clients.balance;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Clients");
            
        }

        public ViewResult Index()
        {
            var clients = _context.TableClients.ToList();
            return View(clients);
        }
    }
}