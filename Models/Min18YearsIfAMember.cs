using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SetifyFinal.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        //Validation features for PAYG and other membership options
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            //Check selected membership type.
            //Also included is Refactoring of magic numbers for more readable code
            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            //Check to see if birthdate is null also
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required!");

            
            //Gives out confirmation that the user should be at least 18
            //ISSUE
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18) ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18!");
        }
    }
}