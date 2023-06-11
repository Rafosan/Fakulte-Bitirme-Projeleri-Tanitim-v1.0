using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class StudentController : Controller
    {
        //StudentManager studentManager=new StudentManager(new EfStudentDal());
        private readonly IStudentService _studentService;
        private readonly IProjectService _projectService;
        private readonly ITeacherService  _teacherService;
        public StudentController(IStudentService studentService, IProjectService projectService,ITeacherService teacherService)
        {
            _studentService = studentService;
            _projectService = projectService;
            _teacherService = teacherService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Project paramatre,int id)
        {
            ProjectValidator validator = new ProjectValidator();
            ValidationResult validationResult = validator.Validate(paramatre);
            if (validationResult.IsValid)
            {
                var values = _studentService.TGetByID(id + 1);
                var values2 = _teacherService.TGetByID(id + 1);
                paramatre.Name = "Post Method Deneme";
                paramatre.Subject = "Post Method Deneme Konu;";
                paramatre.Status = true;
                paramatre.CreationTime = DateTime.Now;
                paramatre.Description = "Post Method Deneme Description";
                paramatre.Student = values;
                paramatre.Teacher = values2;
                _projectService.TAdd(paramatre);
                return RedirectToAction("Index", "Student");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult ProjectUpdate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProjectUpdate(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult ProjectStatus()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProjectStatus(int id)
        {
            return View();
        }

    }
}
