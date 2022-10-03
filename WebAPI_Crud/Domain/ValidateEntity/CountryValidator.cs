using Domain.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ServiceStack.FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ValidateEntity
{
    public class CountryValidator : AbstractValidator<Country>
    {
        
        public CountryValidator(IEnumerable<Country> countries)
        {
            
            RuleFor(x => x.CountryName).NotEmpty().NotNull().WithMessage("The Country Name cannot be blank.");
           
        } 
    }
}






