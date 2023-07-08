using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Fakultemiz_bitirme_projeleri_tanitim.Models.Login;

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
        private int _userId;
        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model, string selectedRole)
        {
            if (selectedRole == Roles.Admin)
            {
                var datavalue = _adminService.TAdminLoginCheck(model.UserName, model.Password);
                if (datavalue != null)
                {
                    _userId = datavalue.ID;
                    TempData["adminId"] = _userId;
                    await SignInAsync(datavalue.UserName, Roles.Admin);
                    return RedirectToAction("Index", "Admin");
                }
            }
            else if (selectedRole == Roles.Teacher)
            {
                var datavalue = _teacherService.TTeacherLoginCheck(model.UserName, model.Password);
                if (datavalue != null)
                {
                    _userId = datavalue.ID; 
                    TempData["teacherId"] = _userId;
                    await SignInAsync(datavalue.UserName, Roles.Teacher);
                    return RedirectToAction("Index", "Teacher");
                }
            }
            else if (selectedRole == Roles.Student)
            {
                var datavalue = _studentService.TStudentLoginCheck(model.UserName, model.Password);
                if (datavalue != null)
                {
                    _userId = datavalue.ID;
                    TempData["studentId"] = _userId;
                    await SignInAsync(datavalue.UserName, Roles.Student);
                    return RedirectToAction("Index", "Student");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View();
        }

        private async Task SignInAsync(string userName, string role)
        {
            var claims = new List<Claim>{
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role)
                };
            var userIdentity = new ClaimsIdentity(claims, "b");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
        }
    }
}
