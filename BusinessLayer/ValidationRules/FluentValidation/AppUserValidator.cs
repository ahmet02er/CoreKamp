using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class AppUserValidator : AbstractValidator<AppUser>
    {

        public AppUserValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Ad Soyad Boş Olamaz...");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail Adresi Boş Olamaz...");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel Boş Olamaz...");
            RuleFor(x => x.NameSurname).MinimumLength(2).WithMessage("Ad Soyad en az 2 karekter olmalıdır...");
            RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karekterlik bir ad Soyad giriniz...");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir e-mail giriniz...");
        }
        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[0-9])[A-Za-z\d]");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
