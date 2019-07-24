using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using InventoryMVC.Models;
using InventoryMVC.Models.ViewModels;

namespace InventoryMVC.Controllers
{
    public class ClientPaymentsController : Controller
    {
        private MyDbContext _context;

        public ClientPaymentsController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ClientPayments
        
        public ViewResult Index()
        {
            var clientPayment = _context.TableClientPayments.Include(c => c.Clients).ToList();
            return View(clientPayment);
        }

        public ActionResult AddPayment()
        {
            var Clients = _context.TableClients.ToList();
            var viewModel = new ClientPaymentViewModel
            {
                ClientPayments = new ClientPayments { datePaid = DateTime.Now},
                Client = Clients
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ClientPayments clientPayments)
        {
            if (!ModelState.IsValid)
            {
                var clientPayment = new ClientPaymentViewModel()
                {
                    ClientPayments = clientPayments,
                    Client = _context.TableClients.ToList()
                };
                return View("AddPayment", clientPayment);
            }
            _context.TableClientPayments.Add(clientPayments);
            var clientInDb = _context.TableClients.Single(c => c.id == clientPayments.ClientsId);
            clientInDb.balance = clientInDb.balance + clientPayments.amountPaid;
            _context.SaveChanges();
            return RedirectToAction("Index", "ClientPayments");

        }


    }
}