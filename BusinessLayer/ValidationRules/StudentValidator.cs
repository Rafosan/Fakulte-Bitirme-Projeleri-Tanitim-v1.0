using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentValidator:AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.NameAndSurname).NotEmpty().WithMessage("Öğrenci adı boş olamaz");
            RuleFor(x => x.NameAndSurname).MinimumLength(2).MaximumLength(150).WithMessage("Öğrenci adı 2-150 karakter aralığında olmalıdır");
            RuleFor(x => x.DepartmentCode).NotEmpty().WithMessage("Öğrenci bölümü boş olamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Öğrenci kullanıcı adı boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Öğrenci adı boş olamaz");
        }
    }
}
