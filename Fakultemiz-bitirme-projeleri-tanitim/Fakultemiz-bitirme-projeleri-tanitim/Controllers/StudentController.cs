using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class StudentController : Controller
    {
        //StudentManager studentManager=new StudentManager(new EfStudentDal());
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            var values = _studentService.TGetAll();
            return View(values);
        }
    }
}
