using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Domain.ValidateEntity
{
    public class CustomerValidator : AbstractValidator<Customer>
    {

        public CustomerValidator(IEnumerable<Customer> customers)
        {
            RuleFor(x => x.Pincode).Must(x => x.ToString().Length == 6).WithMessage("Invalid Pincode");
            RuleFor(x => x.Mobile).Must(x => x.ToString().Length == 10).WithMessage("Invalid Mobile Number");
            RuleFor(x => x.CustomerName).NotEmpty().NotNull().WithMessage("The Customer Name cannot be blank.");
            RuleFor(customer => customer.Email).EmailAddress();
            
        }
    }
} 

