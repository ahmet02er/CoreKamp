using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Olamaz...");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Olamaz...");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Görseli Boş Olamaz...");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen en az 5 karekterlik bir Blog Başlığı giriniz...");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Lütfen en fazla 100 karekterlik bir Blog Başlığı giriniz...");
            RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Lütfen en az 5 karekterlik bir Blog Başlığı giriniz...");
        }

    }
}
