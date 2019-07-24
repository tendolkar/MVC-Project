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
    public class VendorOrdersController : Controller
    {
        private MyDbContext _context;

        public VendorOrdersController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult AddOrder()
        {

            var vendors = _context.TableVendors.ToList();
            var items = _context.TableItems.ToList();
            var viewModel = new VendorOrderViewModel
            {
                VendorOrders = new VendorOrders { date = DateTime.Now },
                Vendor = vendors,
                Item = items
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(VendorOrders vendorOrders)
        {
            if (!ModelState.IsValid)
            {
                var vendorOrder = new VendorOrderViewModel()
                {
                    VendorOrders = vendorOrders,
                    Vendor = _context.TableVendors.ToList(),
                    Item = _context.TableItems.ToList()
                };
                return View("AddOrder", vendorOrder);

            }
            var vendorInDb = _context.TableVendors.Single(c => c.id == vendorOrders.VendorsId);
            var itemInDb = _context.TableItems.Single(c => c.id == vendorOrders.ItemsId);
            if (vendorOrders.id == 0)
            {
                _context.TableVendorOrders.Add(vendorOrders);
                itemInDb.quantity = itemInDb.quantity + vendorOrders.quantity;
                vendorInDb.balance = vendorInDb.balance + vendorOrders.bill;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "VendorOrders");
        }

        public ViewResult Index()
        {
            var vendorOrder = _context.TableVendorOrders.Include(c => c.Vendors).Include(d => d.Items).ToList();
            return View(vendorOrder);
        }
    }
}