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
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Ad Soyad Boş Olamaz...");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Olamaz...");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Olamaz...");
            RuleFor(x => x.WriterImage).NotEmpty().WithMessage("Görsel Boş Olamaz...");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Ad Soyad en az 2 karekter olmalıdır...");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karekterlik bir ad Soyad giriniz...");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Lütfen geçerli bir e-mail giriniz...");
            RuleFor(x => x.WriterPassword).MinimumLength(6).WithMessage("Parola en az 6 karakter olmalıdır...");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Parolanızda en az bir büyük harf, en az bir küçük harf ve rakam olmalıdır...");
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
