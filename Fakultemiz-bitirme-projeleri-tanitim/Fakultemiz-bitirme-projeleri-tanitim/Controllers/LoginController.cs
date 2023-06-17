using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    //[AllowAnonymous]
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
        public IActionResult StudentIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TeacherIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TeacherIndex(Teacher parametre ,string username,string password)
        {
            var datavalue = _teacherService.TTeacherLoginCheck(parametre.UserName, parametre.Password);

            if (datavalue != null)
            {
                HttpContext.Session.SetString("username", parametre.UserName);
                return RedirectToAction("Index", "Teacher");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult AdminIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminIndex(Admin parametre,string username, string password)
        {
            var datavalue = _adminService.TAdminLoginCheck(parametre.UserName, parametre.Password);

            if (datavalue != null)
            {
                HttpContext.Session.SetString("username", parametre.UserName);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
    }
}
