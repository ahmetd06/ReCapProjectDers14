using System;
using Entities;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator: AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.RentDate).NotEmpty();
            RuleFor(p => p.ReturnDate).GreaterThanOrEqualTo(p=>p.RentDate).When(p=>p.ReturnDate !=null).WithMessage("Dönüş tarihi kiralama tarihinden önce olamaz");
            
        }
    }
}
