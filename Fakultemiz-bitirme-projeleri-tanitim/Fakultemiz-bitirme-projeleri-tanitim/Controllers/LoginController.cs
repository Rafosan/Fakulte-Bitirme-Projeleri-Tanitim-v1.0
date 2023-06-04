using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult StudentIndex()
        {
            return View();
        }
        public IActionResult TeacherIndex()
        {
            return View();
        }
    }
}
