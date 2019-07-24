using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using InventoryMVC.Models;
using InventoryMVC.Models.ViewModels;

namespace InventoryMVC.Controllers
{
    public class VendorPaymentsController : Controller
    {
        private MyDbContext _context;

        public VendorPaymentsController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: VendorPayments

        public ViewResult Index()
        {
            var vendorPayment = _context.TableVendorPayments.Include(c => c.Vendors).ToList();
            return View(vendorPayment);
        }

        public ActionResult AddPayment()
        {
            var Vendors = _context.TableVendors.ToList();
            var viewModel = new VendorPaymentViewModel
            {
                VendorPayments = new VendorPayments { datePaid = DateTime.Now },
                Vendor = Vendors
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(VendorPayments vendorPayments)
        {
            if (!ModelState.IsValid)
            {
                var vendorPayment = new VendorPaymentViewModel()
                {
                    VendorPayments = vendorPayments,
                    Vendor = _context.TableVendors.ToList()
                };
                return View("AddPayment", vendorPayment);
            }
            _context.TableVendorPayments.Add(vendorPayments);
            var vendorInDb = _context.TableVendors.Single(c => c.id == vendorPayments.VendorsId);
            vendorInDb.balance = vendorInDb.balance + vendorPayments.amountPaid;
            _context.SaveChanges();
            return RedirectToAction("Index", "VendorPayments");

        }



    }
}