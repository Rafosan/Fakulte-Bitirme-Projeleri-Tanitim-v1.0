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


        public IActionResult ToggleLike(int id)
        {
            var likedProjects = GetLikedProjectsFromCookie(); // Daha önce beğenilen projeleri çerezden al

            if (!likedProjects.Contains(id))
            {
                var project = _projectService.TGetByID(id);
                if (project != null)
                {
                    project.LikeCount++;
                    _projectService.TUpdate(project);
                    likedProjects.Add(id);
                    SetLikedProjectsCookie(likedProjects); // Beğenilen projeleri çereze kaydet
                }
            }

            return RedirectToAction("Index", "Project", new { id });
        }

        private List<int> GetLikedProjectsFromCookie()
        {
            var likedProjectsCookie = Request.Cookies["LikedProjects"];
            if (!string.IsNullOrEmpty(likedProjectsCookie))
            {
                return likedProjectsCookie.Split(',').Select(int.Parse).ToList();
            }
            return new List<int>();
        }

        private void SetLikedProjectsCookie(List<int> likedProjects)
        {
            var likedProjectsString = string.Join(",", likedProjects);
            Response.Cookies.Append("LikedProjects", likedProjectsString, new CookieOptions
            {
                Expires = DateTime.Now.AddYears(1),
                IsEssential = true, // Çerezin olması gerektiğini işaretleyin
            });
        }



    }
}
