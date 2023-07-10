using BusinessLayer.Abstract;
using Fakultemiz_bitirme_projeleri_tanitim.Models.LoginV;
using Fakultemiz_bitirme_projeleri_tanitim.Models.TeacherV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    [Authorize(AuthenticationSchemes = "LoginScheme")]
    [Authorize(Roles = Roles.Teacher)]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IProjectService _projectService;
        private readonly IStudentService _studentService;
        public TeacherController(ITeacherService teacherService, IProjectService projectService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _projectService = projectService;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var studentUserName = User.Identity.Name;
            ViewBag.UserName = studentUserName;

            int teacherId=(int)HttpContext.Session.GetInt32("teacherId");
            var projects = _projectService.TGetProjectsByTeacherId(teacherId);

            var model = new TeacherIndexViewModel()
            {
                Projeler = projects,
                ProjelerOgrenciBilgisi = new List<ProjectWithStudentInfo>()
            };

            foreach (var project in projects)
            {
                var ogrenci = _studentService.TGetByID(project.StudentID);
                var projectWithStudentInfo = new ProjectWithStudentInfo()
                {
                    Project = project,
                    OgrenciAdi = ogrenci.NameAndSurname,
                    OgrenciBolumKodu = ogrenci.DepartmentCode
                };

                model.ProjelerOgrenciBilgisi.Add(projectWithStudentInfo);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int id)
        {
            var values=_projectService.TGetByID(id);
            values.Status = !values.Status;
            _projectService.TUpdate(values);
            return RedirectToAction("Index", "Teacher");
        }
        [HttpGet]
        public IActionResult ProjectStatus()
        {
            int teacherId = (int)HttpContext.Session.GetInt32("teacherId");
            var values = _projectService.TGetProjectsByTeacherId(teacherId);
            return View(values);
        }
        [HttpPost]
        public IActionResult ProjectStatus(int id)
        {
            var values = _projectService.TGetByID(id);
            values.Status=!values.Status;
            _projectService.TUpdate(values);
            return RedirectToAction("ProjectStatus", "Teacher");
        }

        public IActionResult ProjectDelete()
        {
            return View();
        }
        public IActionResult StudentInformation()
        {
            var values=_studentService.TGetAll();
            return View(values);
        }

    }
}
