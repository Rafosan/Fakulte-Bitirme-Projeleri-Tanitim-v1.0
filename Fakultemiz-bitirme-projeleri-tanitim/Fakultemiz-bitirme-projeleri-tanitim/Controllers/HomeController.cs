using System.Diagnostics;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using Fakultemiz_bitirme_projeleri_tanitim.Models.HomeV;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
        public IActionResult Index(int page=1)
        {
            int pageSize = 16;
            var values = _projectService.TGetAll().ToPagedList(page, pageSize);
            var yillar = _categoryService.TGetAll().Where(k => k.Type == Category.Types.Yıl);
            var bolumler = _categoryService.TGetAll().Where(k => k.Type == Category.Types.Bölüm);
            var danismanlar = _categoryService.TGetAll().Where(k => k.Type == Category.Types.Danışman);
            var model = new HomeViewModel()
            {
                Projeler=values,
                Yillar = yillar,
                Bolumler = bolumler,
                Danismanlar = danismanlar,
            };
            return View(model);
        }
    }
}