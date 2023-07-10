using BusinessLayer.Abstract;
using Fakultemiz_bitirme_projeleri_tanitim.Models.LoginV;
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
        public IActionResult Index(int id)
        {
            var values = _projectService.TGetProjectsByTeacherId(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(int id,int id2)
        {
            var values = _projectService.TGetByID(id);
            values.Status = !values.Status;
            _projectService.TUpdate(values);
            return RedirectToAction("Index", "Teacher");
        }
        [HttpGet]
        public IActionResult ProjectStatus(int id)
        {
            var values = _projectService.TGetProjectsByTeacherId(id+1);
            return View(values);
        }
        [HttpPost]
        public IActionResult ProjectStatus(int id,int id2)
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
