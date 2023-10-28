using BusinessLayer.Abstract;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    [AllowAnonymous]
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
		[HttpPost]
		public IActionResult Index(int id , int likecount)
		{
            var values = _projectService.TGetByID(id);
            likecount = values.LikeCount;
            if (values != null)
            {
                values.LikeCount++;
                _projectService.TUpdate(values);
            }
            return RedirectToAction("Index", "Project", new { id = values?.ProjectID });
        }
    }
}
