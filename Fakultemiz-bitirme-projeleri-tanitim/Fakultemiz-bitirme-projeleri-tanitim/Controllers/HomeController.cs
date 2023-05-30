using System.Diagnostics;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
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
        private readonly ICategoryService _categoryService;
        public HomeController(IProjectService projectService, ICategoryService categoryService)
        {
            _projectService = projectService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            //bu şekilde olması gerekiyor
            //mantık olarak
            // sıkıntı var mı?
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