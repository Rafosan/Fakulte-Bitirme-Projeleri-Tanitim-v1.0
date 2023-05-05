using System.Diagnostics;
using BusinessLayer.Abstract;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly IProjectService _projectService;
        public HomeController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        public IActionResult Index()
        {
            var values = _projectService.TGetAll();
            return View(values);
        }

    }
}