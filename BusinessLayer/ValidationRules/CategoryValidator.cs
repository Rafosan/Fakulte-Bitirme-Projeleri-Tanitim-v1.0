using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x=>x.Type).NotEmpty().WithMessage("Kategori türü boş olamaz");
            RuleFor(x=>x.Value).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("Kategori boş olamaz ve 2-50 karakter aralığında olmalıdır.");

        }
    }
}
