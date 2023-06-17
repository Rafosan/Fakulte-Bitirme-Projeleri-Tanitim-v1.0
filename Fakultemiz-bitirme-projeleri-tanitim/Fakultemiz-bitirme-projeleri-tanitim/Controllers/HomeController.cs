using System.Diagnostics;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private readonly IProjectService _projectService;
        private readonly ICategoryService _categoryService;
        public HomeController(IProjectService projectService, ICategoryService categoryService)
        {
            _projectService = projectService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var values = _projectService.TGetAll();
            var values2 = _categoryService.TGetAll();
            var model = new HomeViewModel()
            {
                Projeler=values,
                Kategoriler=values2,
            };
            return View(model);
        }
    }
}