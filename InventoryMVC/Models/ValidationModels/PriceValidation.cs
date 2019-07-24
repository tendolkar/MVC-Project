using InventoryMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ValidationModels
{
    public class PriceValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var item = (Items)validationContext.ObjectInstance;

            if (int.TryParse(item.sellingPrice.ToString(), out int n) == false)
            {

                return new ValidationResult("Insert balance in integers");
            }
            else if (item.sellingPrice == 0)
            {
                return new ValidationResult("Selling price cannot be null");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}