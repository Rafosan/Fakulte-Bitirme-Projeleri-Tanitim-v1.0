using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService  _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var values= _categoryService.TGetAll();
            return View(values);
        }
    }
}
