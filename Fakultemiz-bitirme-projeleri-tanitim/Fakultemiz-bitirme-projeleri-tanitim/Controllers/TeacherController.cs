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
            ViewBag.TeacherName = User.Identity.Name ?? string.Empty;
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
            ViewBag.TeacherName = User.Identity.Name ?? string.Empty;
            return View(model);
        }
        [HttpPost]
        public IActionResult ProjectStatus(int id)
        {
            var values = _projectService.TGetByID(id);
            values.Status=!values.Status;
            _projectService.TUpdate(values);
            return RedirectToAction("ProjectStatus", "Teacher");
        }
        [HttpGet]
        public IActionResult ProjectDelete()
        {
            int teacherId = (int)HttpContext.Session.GetInt32("teacherId");
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
            ViewBag.TeacherName = User.Identity.Name ?? string.Empty;
            return View(model);
        }
        [HttpPost]
        public IActionResult ProjectDelete(int id)
        {
            var values = _projectService.TGetByID(id);
            _projectService.TDelete(values);
            return RedirectToAction("ProjectDelete", "Teacher");
        }
        public IActionResult StudentInformation()
        {
            var values=_studentService.TGetAll();
            ViewBag.TeacherName = User.Identity.Name ?? string.Empty;
            return View(values);
        }

    }
}
