using System;
using Entities;
using FluentValidation;
namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(5);
            RuleFor(p => p.Name).MaximumLength(20);
        }
    }
}
