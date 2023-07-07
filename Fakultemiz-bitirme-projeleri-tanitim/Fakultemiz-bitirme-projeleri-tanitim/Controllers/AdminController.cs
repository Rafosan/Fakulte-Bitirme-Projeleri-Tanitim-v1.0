using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Fakultemiz_bitirme_projeleri_tanitim.Models.Login;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    [Authorize(AuthenticationSchemes = "LoginScheme")]
    [Authorize(Roles = Roles.Admin)]
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
            var username = User.Identity.Name;
            ViewBag.Username = username;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Teacher parametre)
        {
            TeacherValidator validator = new TeacherValidator();
            ValidationResult validationResult = validator.Validate(parametre);
            if (validationResult.IsValid)
            {
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
            var teacher = _teacherService.TGetByID(id);
            if (teacher != null)
            {
                _teacherService.TDelete(teacher);
            }
            return RedirectToAction("TeacherDelete");
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
                parametre.Status = true;
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

        [HttpGet]
        public IActionResult StudentDelete()
        {
            var values=_studentService.TGetAll();
            return View(values);
        }
        [HttpPost]
        public IActionResult StudentDelete(int id)
        {
            var student = _studentService.TGetByID(id);
            if (student != null)
            {
                _studentService.TDelete(student);
            }
            return RedirectToAction("StudentDelete");
        }

        public IActionResult StudentList()
        {
            var values=_studentService.TGetAll();
            return View(values);
        }
    }
}
