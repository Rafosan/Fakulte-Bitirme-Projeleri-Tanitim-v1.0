using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Fakultemiz_bitirme_projeleri_tanitim.Models.LoginV;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    [Authorize(AuthenticationSchemes = "LoginScheme")]
    [Authorize(Roles = Roles.Student)]
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
            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            var values=_projectService.TGetProjectByStudentId(studentId);
            if (values != null)
            {
                return RedirectToAction("ProjectStatus", "Student");
            }
            var studentUserName = User.Identity.Name;
            ViewBag.UserName = studentUserName;

            var teacherList =_teacherService.TGetAll();
            var selectList = new SelectList(teacherList, "ID", "NameAndSurname");
            ViewBag.TeacherList = selectList;
            
            return View();
        }
        [HttpPost]
        public IActionResult Index(Project paramatre, int teacherId,List<IFormFile> Image1, List<IFormFile> Image2, List<IFormFile> Image3, List<IFormFile> Image4)
        {
            var studentId = (int)HttpContext.Session.GetInt32("studentId");
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
                var values = _studentService.TGetByID(studentId);
                values.NameAndSurname = paramatre.Student.NameAndSurname;
                _studentService.TUpdate(values);
                paramatre.Student = values;
                paramatre.Teacher = _teacherService.TGetByID(teacherId);
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
        public IActionResult ProjectUpdate()
        {
            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            var values = _projectService.TGetProjectByStudentId(studentId);
            if (values == null)
            {
                return RedirectToAction("Index", "Student");
            }
            var studentUserName = User.Identity.Name;
            ViewBag.UserName = studentUserName;

            var teacherList = _teacherService.TGetAll();
            var selectList = new SelectList(teacherList, "ID", "NameAndSurname");
            ViewBag.TeacherList = selectList;

            return View(values);
        }
        [HttpPost]
        public IActionResult ProjectUpdate(Project paramatre, int teacherId, List<IFormFile> Image1, List<IFormFile> Image2, List<IFormFile> Image3, List<IFormFile> Image4)
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
                paramatre.Teacher = _teacherService.TGetByID(teacherId);
                paramatre.UpdateTime = DateTime.Now;
                paramatre.Status = false;
                _projectService.TUpdate(paramatre);
                return RedirectToAction("ProjectUpdate", "Student");
            }
            return View();
        }
        
        public IActionResult ProjectStatus()
        {
            var studentUserName = User.Identity.Name;
            ViewBag.UserName = studentUserName;

            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            var values = _projectService.TGetProjectByStudentId(studentId);
            return View(values);
        }

        [HttpGet]
        public IActionResult Information()
        {
            var studentUserName = User.Identity.Name;
            ViewBag.UserName = studentUserName;

            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            var values = _studentService.TGetByID(studentId);
            return View(values); 
        }
        [HttpPost]
        public IActionResult Information(Student parametre)
        {
            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            var values=_studentService.TGetByID(studentId);
            values.Number = parametre.Number;
            values.EMail = parametre.EMail;
            StudentValidator validator = new StudentValidator();
            ValidationResult validationResult = validator.Validate(values);
            if (validationResult.IsValid) 
            {
                values.UpdateTime = DateTime.Now;
                _studentService.TUpdate(values);
                return RedirectToAction("Information", "Student");
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
    }
}
