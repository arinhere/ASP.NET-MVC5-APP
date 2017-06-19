using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ValidateAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers) validationContext.ObjectInstance;

            var customerAge = System.DateTime.Today.Year - customer.BirthDate.Value.Year;
            if (customerAge >= 18) ? ValidationResult.Success : new ValidationResult("You must be over 18 years to register.");
        }

    }
}