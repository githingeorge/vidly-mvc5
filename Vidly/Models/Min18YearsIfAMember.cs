using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
             
            if (customer.DateOfBirth == null)
                return new ValidationResult("Date of birth is required");

            var age = DateTime.Today.Year - customer.DateOfBirth.Value.Year;
            if (age >= 18)
                return ValidationResult.Success;
            
           return new ValidationResult("The customer should be atleast 18Yrs of age to go on a membership");
        }
    }
}