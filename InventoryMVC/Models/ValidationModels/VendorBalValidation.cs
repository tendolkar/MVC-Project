using InventoryMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ValidationModels
{
    public class VendorBalValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vendor = (Vendors)validationContext.ObjectInstance;

            if (int.TryParse(vendor.balance.ToString(), out int n) == false)
            {

                return new ValidationResult("Insert balance in integers");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}