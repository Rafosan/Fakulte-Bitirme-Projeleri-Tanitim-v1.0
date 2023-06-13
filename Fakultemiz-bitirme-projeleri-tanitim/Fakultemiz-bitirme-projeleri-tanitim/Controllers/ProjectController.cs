using BusinessLayer.Abstract;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public IActionResult Index(int id)
        {
            var values = _projectService.TGetListWithExpressionStudentAndTeacher(id).FirstOrDefault();
            return View(values);
        }
    }
}
