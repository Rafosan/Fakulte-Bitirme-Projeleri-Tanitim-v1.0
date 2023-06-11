using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        public AdminController(IAdminService adminService, ITeacherService teacherService, IStudentService studentService)
        {
            _adminService = adminService;
            _teacherService = teacherService;
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Teacher parametre)
        {
            TeacherValidator validator = new TeacherValidator();
            ValidationResult validationResult = validator.Validate(parametre);
            if (validationResult.IsValid)
            {
                parametre.MajorScienceCode = 1000;
                parametre.Status = true;
                _teacherService.TAdd(parametre);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult TeacherDelete()
        {
            var values = _teacherService.TGetAll();
            return View(values);
        }
        [HttpPost]
        public IActionResult TeacherDelete(int id)
        {
            return View();
        }

        public IActionResult TeacherList()
        {
            var values=_teacherService.TGetAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult StudentIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentIndex(Student parametre)
        {
            StudentValidator validator = new StudentValidator();
            ValidationResult validationResult = validator.Validate(parametre);
            if (validationResult.IsValid)
            {
                _studentService.TAdd(parametre);
                return RedirectToAction("StudentIndex", "Admin");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult StudentDelete()
        {
            var values=_studentService.TGetAll();
            return View(values);
        }
        public IActionResult StudentList()
        {
            var values=_studentService.TGetAll();
            return View(values);
        }


    }
}
