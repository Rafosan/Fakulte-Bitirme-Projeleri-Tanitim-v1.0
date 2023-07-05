using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    [Authorize(AuthenticationSchemes = "LoginScheme")]
    public class StudentController : Controller
    {
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
            var username = User.Identity.Name;
            ViewBag.Username = username;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Project paramatre,int id,List<IFormFile> Image1, List<IFormFile> Image2, List<IFormFile> Image3, List<IFormFile> Image4)
        {
            List<List<IFormFile>> imageLists = new List<List<IFormFile>> { Image1, Image2, Image3, Image4 };
            List<byte[]> fileDataList = new List<byte[]>();
            foreach (var imageList in imageLists)
            {
                var file = imageList.FirstOrDefault(f => f.Length > 0);
                if (file != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileDataList.Add(ms.ToArray());
                    }
                }
            }
            paramatre.Image1 = fileDataList.ElementAtOrDefault(0);
            paramatre.Image2 = fileDataList.ElementAtOrDefault(1);
            paramatre.Image3 = fileDataList.ElementAtOrDefault(2);
            paramatre.Image4 = fileDataList.ElementAtOrDefault(3);
            ProjectValidator validator = new ProjectValidator();
            ValidationResult validationResult = validator.Validate(paramatre);
            
            if (validationResult.IsValid)
            { 
                paramatre.Student = _studentService.TGetByID(id+1);
                paramatre.Teacher = _teacherService.TGetByID(id+1);
                paramatre.CreationTime = DateTime.Now;
                paramatre.Status = false;
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
        public IActionResult ProjectUpdate(int id)
        {
            var values=_projectService.TGetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult ProjectUpdate(Project paramatre,int id)
        {
            ProjectValidator validator = new ProjectValidator();
            ValidationResult validationResult = validator.Validate(paramatre);
            if (validationResult.IsValid)
            {
                paramatre.Student = _studentService.TGetByID(id + 1);
                paramatre.Teacher = _teacherService.TGetByID(1);
                paramatre.UpdateTime = DateTime.Now;
                paramatre.Status = false;
                _projectService.TUpdate(paramatre);
                return RedirectToAction("ProjectUpdate", "Student");
            }
            return View();
        }
        
        public IActionResult ProjectStatus(int id)
        {
            var values = _projectService.TGetByID(id+1);
            return View(values);
        }

        public IActionResult Information()
        { 
            var values=_studentService.TGetAll();
            return View(values); 
        }


    }
}
