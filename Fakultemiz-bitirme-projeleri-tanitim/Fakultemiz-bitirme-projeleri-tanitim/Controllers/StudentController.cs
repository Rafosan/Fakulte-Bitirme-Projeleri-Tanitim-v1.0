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
        private readonly ICategoryService _categoryService;
        public StudentController(IStudentService studentService, IProjectService projectService, ITeacherService teacherService, ICategoryService categoryService)
        {
            _studentService = studentService;
            _projectService = projectService;
            _teacherService = teacherService;
            _categoryService = categoryService;
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

            ViewBag.TeacherList = new SelectList(_teacherService.TGetAll(), "ID", "NameAndSurname");
            ViewBag.UserName = User.Identity.Name;
            return View();
        }
        [HttpPost]
        public IActionResult Index(Project paramatre, int teacherId,List<IFormFile> Image1, List<IFormFile> Image2, List<IFormFile> Image3, List<IFormFile> Image4)
        {
            ViewBag.TeacherList = new SelectList(_teacherService.TGetAll(), "ID", "NameAndSurname", teacherId);
            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            
            List<List<IFormFile>> imageLists = new List<List<IFormFile>> { Image1, Image2, Image3, Image4 };
            List<byte[]> fileDataList = GetFileDataList(imageLists);
            paramatre.Image1 = fileDataList.ElementAtOrDefault(0);
            paramatre.Image2 = fileDataList.ElementAtOrDefault(1);
            paramatre.Image3 = fileDataList.ElementAtOrDefault(2);
            paramatre.Image4 = fileDataList.ElementAtOrDefault(3);

            ProjectValidator validator = new ProjectValidator();
            ValidationResult validationResult = validator.Validate(paramatre);
            if (validationResult.IsValid)
            {
                var yearCategory = _categoryService.TGetCategoryByValue(Category.Types.Yıl, paramatre.CreationTime.Value.Year.ToString());
                if(yearCategory==null)
                {
                    yearCategory = new Category
                    {
                        Type = Category.Types.Yıl,
                        Value = paramatre.CreationTime.Value.Year.ToString(),
                        CreationTime = DateTime.Now,
                        Status = true
                    };
                    _categoryService.TAdd(yearCategory);
                }

                var values = _studentService.TGetByID(studentId);
                values.NameAndSurname = paramatre.Student.NameAndSurname;
                values.UpdateTime = DateTime.Now;
                _studentService.TUpdate(values);

                paramatre.Student = values;
                paramatre.Teacher = _teacherService.TGetByID(teacherId);
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

            ViewBag.TeacherList = new SelectList(_teacherService.TGetAll(), "ID", "NameAndSurname");
            ViewBag.UserName = User.Identity.Name;
            return View(values);
        }
        [HttpPost]
        public IActionResult ProjectUpdate(Project parametre,int teacherId, List<IFormFile> Image1, List<IFormFile> Image2, List<IFormFile> Image3, List<IFormFile> Image4)
        {
            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            var project = _projectService.TGetProjectByStudentId(studentId);
            ViewBag.TeacherList = new SelectList(_teacherService.TGetAll(), "ID", "NameAndSurname", teacherId);

            List<List<IFormFile>> imageLists = new List<List<IFormFile>> { Image1, Image2, Image3, Image4 };
            List<byte[]> fileDataList = GetFileDataList(imageLists);
            project.Image1 = fileDataList.ElementAtOrDefault(0);
            project.Image2 = fileDataList.ElementAtOrDefault(1);
            project.Image3 = fileDataList.ElementAtOrDefault(2);
            project.Image4 = fileDataList.ElementAtOrDefault(3);

            ProjectValidator validator = new ProjectValidator();
            ValidationResult validationResult = validator.Validate(project);
            if (validationResult.IsValid)
            {
                project.Name = parametre.Name; 
                project.Description=parametre.Description;
                project.Subject = parametre.Subject;

                var values = _studentService.TGetByID(studentId);
                values.NameAndSurname = parametre.Student.NameAndSurname;
                values.UpdateTime=DateTime.Now;
                _studentService.TUpdate(values);

                project.Student = values;
                project.Teacher = _teacherService.TGetByID(teacherId);
                project.UpdateTime = DateTime.Now;
                project.Status = false;
                _projectService.TUpdate(project);
                return RedirectToAction("ProjectStatus", "Student");
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
        
        public IActionResult ProjectStatus()
        {
            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            var values = _projectService.TGetProjectByStudentId(studentId);
            ViewBag.UserName = User.Identity.Name;
            return View(values);
        }

        [HttpGet]
        public IActionResult Information()
        {
            var studentId = (int)HttpContext.Session.GetInt32("studentId");
            var values = _studentService.TGetByID(studentId);
            ViewBag.UserName = User.Identity.Name;
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
            return View(values);
        }



        private List<byte[]> GetFileDataList(List<List<IFormFile>> imageLists)
        {
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
            return fileDataList;
        }
    }
}
