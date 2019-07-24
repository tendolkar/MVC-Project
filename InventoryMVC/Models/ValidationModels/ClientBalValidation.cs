using InventoryMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryMVC.Models.ValidationModels
{
    public class ClientBalValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var client = (Clients)validationContext.ObjectInstance;
            
            if (int.TryParse(client.balance.ToString(),out int n) == false)
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