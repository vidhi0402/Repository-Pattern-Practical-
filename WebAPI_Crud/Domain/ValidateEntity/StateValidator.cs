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
    public class StateValidator : AbstractValidator<State>
    {

        public StateValidator(IEnumerable<State> states)
        {

            RuleFor(x => x.StateName).NotEmpty().NotNull().WithMessage("The State Name cannot be blank.");

        }
    }
}






