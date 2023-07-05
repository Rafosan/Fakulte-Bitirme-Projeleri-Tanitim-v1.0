using BusinessLayer.Abstract;
using Fakultemiz_bitirme_projeleri_tanitim.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        public LoginController(IAdminService adminService, ITeacherService teacherService, IStudentService studentService)
        {
            _adminService = adminService;
            _teacherService = teacherService;
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model, string selectedRole)
        {
            if (selectedRole == "Admin")
            {
                var datavalue = _adminService.TAdminLoginCheck(model.UserName, model.Password);
                if (datavalue != null)
                {
                    await SignInAsync(datavalue.UserName);
                    return RedirectToAction("Index", "Admin");
                }
            }
            else if (selectedRole == "Teacher")
            {
                var datavalue = _teacherService.TTeacherLoginCheck(model.UserName, model.Password);
                if (datavalue != null)
                {
                    await SignInAsync(datavalue.UserName);
                    return RedirectToAction("Index", "Teacher");
                }
            }
            else if (selectedRole == "Student")
            {
                var datavalue = _studentService.TStudentLoginCheck(model.UserName, model.Password);
                if (datavalue != null)
                {
                    await SignInAsync(datavalue.UserName);
                    return RedirectToAction("Index", "Student");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View();
        }

        private async Task SignInAsync(string userName)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, userName)
                };
            var userIdentity = new ClaimsIdentity(claims, "c");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
        }
    }
}
