using System;
using Entities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.Description).Must(StartWithKiralik).WithMessage("Araç ismi Kiralık ile başlamalı");
        }

        private bool StartWithKiralik(string arg)
        {
            return arg.StartsWith("Kiralık ");
        }
    }
}
