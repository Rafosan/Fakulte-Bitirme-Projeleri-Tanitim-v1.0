using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Fakultemiz_bitirme_projeleri_tanitim.Models.LoginV;
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
        private readonly ICategoryService _categoryService;
        public AdminController(IAdminService adminService, ITeacherService teacherService, IStudentService studentService, ICategoryService categoryService)
        {
            _adminService = adminService;
            _teacherService = teacherService;
            _studentService = studentService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.AdminName = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Teacher parametre)
        {
            TeacherValidator validator = new TeacherValidator();
            ValidationResult validationResult = validator.Validate(parametre);
            if (validationResult.IsValid)
            {
                parametre.CreationTime = DateTime.Now;
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
            ViewBag.AdminName = User.Identity.Name;
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
            ViewBag.AdminName = User.Identity.Name;
            return View(values);
        }

        [HttpGet]
        public IActionResult StudentIndex()
        {
            ViewBag.AdminName = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public IActionResult StudentIndex(Student parametre)
        {
            StudentValidator validator = new StudentValidator();
            ValidationResult validationResult = validator.Validate(parametre);
            if (validationResult.IsValid)
            {
                parametre.CreationTime = DateTime.Now;
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
            ViewBag.AdminName = User.Identity.Name;
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
            return RedirectToAction("StudentDelete","Admin");
        }

        public IActionResult StudentList()
        {
            var values=_studentService.TGetAll();
            ViewBag.AdminName = User.Identity.Name;
            return View(values);
        }
        [HttpGet]
        public IActionResult AdminIndex()
        {
            ViewBag.AdminName = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public IActionResult AdminIndex(Admin parametre)
        {
            AdminValidator validatior = new AdminValidator();
            ValidationResult validationResult=validatior.Validate(parametre);
            if (validationResult.IsValid)
            {
                parametre.CreationTime = DateTime.Now;
                parametre.Status = true;
                _adminService.TAdd(parametre);
                return RedirectToAction("AdminIndex", "Admin");
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
        public IActionResult AdminDelete()
        {
            var adminId = (int)HttpContext.Session.GetInt32("adminId");
            var values=_adminService.TGetAll();
            ViewBag.AdminId = adminId;
            ViewBag.AdminName = User.Identity.Name;
            return View(values);
        }
        [HttpPost]
        public IActionResult AdminDelete(int id)
        {
            var admin=_adminService.TGetByID(id);
            if (admin != null)
            {
                _adminService.TDelete(admin);
            }
            return RedirectToAction("AdminDelete", "Admin");
        }
        public IActionResult AdminList()
        {
            var values =_adminService.TGetAll();
            ViewBag.AdminName = User.Identity.Name;
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryIndex()
        {
            ViewBag.AdminName = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public IActionResult CategoryIndex(Category parametre)
         {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult validationResult = validator.Validate(parametre);
            if (validationResult.IsValid)
            {
                parametre.CreationTime = DateTime.Now;
                parametre.Status=true;
                _categoryService.TAdd(parametre);
                return RedirectToAction("CategoryIndex", "Admin");
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
        public IActionResult CategoryDelete()
        {
            var values =_categoryService.TGetAll();
            ViewBag.AdminName = User.Identity.Name;
            return View(values);
        }
        [HttpPost]
        public IActionResult CategoryDelete(int id)
        {
            var category=_categoryService.TGetByID(id);
            if (category != null)
            {
                _categoryService.TDelete(category);
            }
            return RedirectToAction("CategoryDelete", "Admin");
        }
        public IActionResult CategoryList()
        {
            var values = _categoryService.TGetAll();
            ViewBag.AdminName = User.Identity.Name;
            return View(values);
        }
    }
}
