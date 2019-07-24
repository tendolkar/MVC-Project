using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ValidationModels
{
    public class VendorBillValidation : ValidationAttribute
    {
        private MyDbContext _context = new MyDbContext();

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vendorOrder = (VendorOrders)validationContext.ObjectInstance;
            var item = _context.TableItems.SingleOrDefault(c => c.id == vendorOrder.ItemsId);
            if ((vendorOrder.bill/vendorOrder.quantity) < item.sellingPrice)
            {

                return new ValidationResult("Result in your loss!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}