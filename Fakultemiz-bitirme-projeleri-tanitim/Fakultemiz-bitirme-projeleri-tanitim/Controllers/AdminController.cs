using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Fakultemiz_bitirme_projeleri_tanitim.Models.LoginV;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
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
		private void SetAdminNameInViewBag()
		{
			if (User.Identity.IsAuthenticated)
			{
				ViewBag.AdminName = User.Identity.Name;
			}
            else
            {
                ViewBag.AdminName = "AdminDeneme";

			}
		}
		[HttpGet]
        public IActionResult Index()
        {
			SetAdminNameInViewBag();
			return View();
        }
        [HttpPost]
        public IActionResult Index(Teacher parametre)
        {
            TeacherValidator validator = new TeacherValidator();
            ValidationResult validationResult = validator.Validate(parametre);
            if (validationResult.IsValid)
            {
                var danismancategory = _categoryService.TGetCategoryByValue(Category.Types.Danışman, parametre.NameAndSurname);
                if (danismancategory == null)
                {
                    danismancategory = new Category
                    {
                        Type = Category.Types.Danışman,
                        Value = parametre.NameAndSurname,
                        CreationTime = DateTime.Now,
                        Status = true
                    };
                    _categoryService.TAdd(danismancategory);
                }

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
			SetAdminNameInViewBag();
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
			SetAdminNameInViewBag();
			return View(values);
        }

        [HttpGet]
        public IActionResult StudentIndex()
        {
			SetAdminNameInViewBag();
			return View();
        }
        [HttpPost]
        public IActionResult StudentIndex(Student parametre)
        {
            StudentValidator validator = new StudentValidator();
            ValidationResult validationResult = validator.Validate(parametre);
            if (validationResult.IsValid)
            {
                var studentCategory = _categoryService.TGetCategoryByValue(Category.Types.Bölüm, parametre.DepartmentCode.ToString());
                if(studentCategory==null)
                {
                    studentCategory = new Category
                    {
                        Type = Category.Types.Bölüm,
                        Value = parametre.DepartmentCode.ToString(),
                        CreationTime = DateTime.Now,
                        Status = true
                    };
                    _categoryService.TAdd(studentCategory);
                }

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
			SetAdminNameInViewBag();
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
			SetAdminNameInViewBag();
			return View(values);
        }

        [HttpGet]
        public IActionResult AdminIndex()
        {
			SetAdminNameInViewBag();
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
            ViewBag.AdminId = adminId;
			SetAdminNameInViewBag();
            var values = _adminService.TGetAll();
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
            SetAdminNameInViewBag();
            return View(values);
        }

        [HttpGet]
        public IActionResult CategoryIndex()
        {
			SetAdminNameInViewBag();
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
                parametre.Status = true;
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
            SetAdminNameInViewBag();
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
            SetAdminNameInViewBag();
            return View(values);
        }
    }
}
