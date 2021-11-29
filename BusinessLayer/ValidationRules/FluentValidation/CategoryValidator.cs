using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.FluentValidation
{
   public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Olamaz...");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karekterlik bir Kategori adı giriniz...");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karekterlik bir Kategori adı giriniz...");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklaması Boş Olamaz...");
            RuleFor(x => x.CategoryDescription).MinimumLength(5).WithMessage("Lütfen en az 5 karekterlik bir Kategori açıklaması giriniz...");
            RuleFor(x => x.CategoryDescription).MaximumLength(250).WithMessage("Lütfen en fazla 250 karekterlik bir Kategori açıklaması giriniz...");
        }
       
    }
}
