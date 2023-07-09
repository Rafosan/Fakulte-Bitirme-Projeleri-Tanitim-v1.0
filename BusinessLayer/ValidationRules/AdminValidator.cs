using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator() 
        {
            RuleFor(x => x.NameAndSurname).NotEmpty().MinimumLength(2).MaximumLength(50).WithMessage("Admin ad soyadı boş olamaz ve 2-50 karakter arasında olmalıdır. ");
            RuleFor(x=>x.UserName).NotEmpty().MinimumLength(2).MaximumLength(20).WithMessage("Admin kulanıcı adı boş olamaz ve 2-20 karakter arasında olmalıdır.");
            RuleFor(x=>x.Password).NotEmpty().MinimumLength(2).MaximumLength(20).WithMessage("Admin şifresi boş olamaz ve 2-20 karakter arasında olmalıdır.");
        }
    }
}
