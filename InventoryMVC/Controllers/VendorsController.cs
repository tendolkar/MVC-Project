using InventoryMVC.Models;
using InventoryMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryMVC.Controllers
{
    public class VendorsController : Controller
    {
        private MyDbContext _context;

        public VendorsController()
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
            var vendor = _context.TableVendors.SingleOrDefault(c => c.id == id);
            var vendorOrders = _context.TableVendorOrders.Where(c => c.VendorsId == id).Include(d => d.Items).ToList();
            var vendorPayments = _context.TableVendorPayments.Where(c => c.VendorsId == id).ToList();
            var viewModel = new VendorViewModel
            {
                Vendor = vendor,
                VendorOrders = vendorOrders,
                VendorPayments = vendorPayments,
            };

            if (vendor == null)
            {
                return HttpNotFound();

            }
            return View(viewModel);
        }

        public ActionResult Update(int id)
        {

            var vendor = _context.TableVendors.SingleOrDefault(c => c.id == id);
            if (vendor == null)
            {
                return HttpNotFound();

            }
            return View("VendorForm", vendor);
        }

        public ActionResult Delete(int id)
        {

            var vendor = _context.TableVendors.SingleOrDefault(c => c.id == id);
            if (vendor == null)
            {
                return HttpNotFound();

            }
            return View(vendor);
        }

        public ActionResult AddVendor()
        {
            var vendor = new Vendors();
            return View("VendorForm", vendor);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Vendors vendors)
        {
            if (!ModelState.IsValid)
            {
                var vendor = new Vendors();
                return View("VendorForm", vendor);
            }

            if (vendors.id == 0)
            {
                _context.TableVendors.Add(vendors);
            }
            else
            {
                var vendorInDb = _context.TableVendors.Single(c => c.id == vendors.id);
                vendorInDb.name = vendors.name;
                vendorInDb.address = vendors.address;
                vendorInDb.contact = vendors.contact;
                vendorInDb.email = vendors.email;
                vendorInDb.balance = vendors.balance;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Vendors");

        }

        public ViewResult Index()
        {
            var vendors = _context.TableVendors.ToList();
            return View(vendors);
        }
    }
}