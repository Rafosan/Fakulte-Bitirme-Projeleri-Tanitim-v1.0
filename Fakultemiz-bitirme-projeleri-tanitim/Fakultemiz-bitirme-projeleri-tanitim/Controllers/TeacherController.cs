using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly IProjectService _projectService;
        public TeacherController(ITeacherService teacherService, IProjectService projectService)
        {
            _teacherService = teacherService;
            _projectService = projectService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values=_projectService.TGetAll();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(int id)
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

    }
}
