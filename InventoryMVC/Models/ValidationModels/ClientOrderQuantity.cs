using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ValidationModels
{
    public class ClientOrderQuantity : ValidationAttribute
    {
        private MyDbContext _context = new MyDbContext();
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var clientOrder = (ClientOrders)validationContext.ObjectInstance;
            var item = _context.TableItems.SingleOrDefault(c => c.id == clientOrder.ItemsId);
            if (clientOrder.quantity>item.quantity)
            {

                return new ValidationResult("Out of stock");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}