using System;
using Entities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
            RuleFor(p => p.CompanyName).MinimumLength(5);
            RuleFor(p => p.CompanyName).MaximumLength(50);
        }
    }
}
