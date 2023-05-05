using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        { 
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            var values= _adminService.TGetAll();
            return View(values);
        }
    }
}
