using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeacherValidator:AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(x => x.NameAndSurname).NotEmpty().WithMessage("Danışman adı boş olamaz");
            RuleFor(x => x.NameAndSurname).MinimumLength(2).MaximumLength(50).WithMessage("Danışman adı 2-50 karakter aralığında olmalıdır");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Danışman kullanıcı adı boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Danışman şifre boş olamaz");
        }
    }
}
