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
    public class ItemsController : Controller
    {
        private MyDbContext _context;

        public ItemsController()
        {
            _context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Items

        public ActionResult Details(int id)
        {

            var item = _context.TableItems.SingleOrDefault(c => c.id == id);
            var clientOrders = _context.TableClientOrders.Include(d=>d.Clients).Where(c => c.ItemsId == id).ToList();
            var vendorOrders = _context.TableVendorOrders.Include(d=>d.Vendors).Where(c => c.ItemsId == id).ToList();
            var viewModel = new ItemViewModel
            {
                Item = item,
                ClientOrders = clientOrders,
                VendorOrders = vendorOrders
            };

            if (item == null)
            {
                return HttpNotFound();

            }
            return View(viewModel);
        }

        public ActionResult Update(int id)
        {

            var item = _context.TableItems.SingleOrDefault(c => c.id == id);
            if (item == null)
            {
                return HttpNotFound();

            }
            return View("ItemForm", item);
        }

        public ActionResult Delete(int id)
        {

            var item = _context.TableItems.SingleOrDefault(c => c.id == id);
            if (item == null)
            {
                return HttpNotFound();

            }
            return View(item);
        }

        public ActionResult AddItem()
        {
            var item = new Items();
            return View("ItemForm", item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Items items)
        {
            if (!ModelState.IsValid)
            {

                var item = new Items();
                return View("ItemForm", item);

            }
            if (items.id == 0)
            {
                _context.TableItems.Add(items);
            }

            else
            {
                var itemInDb = _context.TableItems.Single(c => c.id == items.id);
                itemInDb.name = items.name;
                itemInDb.description = items.description;
                itemInDb.quantity = items.quantity;
                itemInDb.sellingPrice = items.sellingPrice;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Items");
        
        }

        public ViewResult Index()
        {
            var items = _context.TableItems.ToList();
            return View(items);
        }
    }
}