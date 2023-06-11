using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult StudentIndex()
        {
            if (User.Identity.IsAuthenticated && User.Identity.Name == "Student")
            {
                // Admin rolüne sahip kullanıcıları AdminIndex sayfasına yönlendirin
                return RedirectToAction("AdminIndex", "Home");
            }
            else
            { 
                return View();
            }
            
        }
        public IActionResult TeacherIndex()
        {
            return View();
        }
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
