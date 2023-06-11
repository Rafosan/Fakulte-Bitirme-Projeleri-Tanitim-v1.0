using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        public AdminController(IAdminService adminService, ITeacherService teacherService, IStudentService studentService)
        {
            _adminService = adminService;
            _teacherService = teacherService;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult StudentIndex() 
        {
        return View();
        }
        public IActionResult StudentDelete()
        {
            return View();
        }
        public IActionResult StudentList() 
        { 
            return View();
        }
        public IActionResult TeacherIndex()
        {
            return View();
        }
        public IActionResult TeacherDelete()
        {
            return View();
        }
        public IActionResult TeacherList()
        {
            return View();
        }


    }
}
