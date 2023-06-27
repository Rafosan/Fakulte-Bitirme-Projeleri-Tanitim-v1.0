using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ProjectValidator:AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş olamaz");
            RuleFor(x=>x.Name).MinimumLength(2).MaximumLength(200).WithMessage("Proje adı 10-200 karakter aralığında olmalıdır");
            RuleFor(x=>x.Subject).MinimumLength(10).MaximumLength(500).WithMessage("Proje konusu 10-500 karakter aralığında olmalıdır");
            RuleFor(x=>x.Description).MinimumLength(10).MaximumLength(500).WithMessage("Proje açıklaması 10-500 karakter aralığında olmalıdır");
            RuleFor(x => x.Image1).NotNull().WithMessage("Resim1 boş olamaz");
            RuleFor(x => x.Image2).NotNull().WithMessage("Resim2 boş olamaz");
            RuleFor(x => x.Image3).NotNull().WithMessage("Resim3 boş olamaz");
            RuleFor(x => x.Image4).NotNull().WithMessage("Resim4 boş olamaz");
        }
    }
}
