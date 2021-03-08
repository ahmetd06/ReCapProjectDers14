using System;
using System.Text.RegularExpressions;
using Core.Entities.Concrete;

using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<Core.Entities.Concrete.User>
    {
        public UserValidator()
        {
            
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
            //RuleFor(p => p.Password).NotEmpty();
            //RuleFor(p => p.Password).MinimumLength(8);
            //RuleFor(p => p.Password).MaximumLength(15);
            //RuleFor(u => u.Password).Must(IsPasswordValid).WithMessage("Şifrenizde en az bir büyük, küçük harf ve rakam bulunmak zorundadır. ");
            RuleFor(p => p.Email).EmailAddress();

        }

        //bu metod başka bir ödevci arkadaşın kodundan görme ve almadır. saygılarımla.
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$");
            return regex.IsMatch(arg);
        }
    }
}
