using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class StudentController : Controller
    {
        StudentManager studentManager=new StudentManager(new EfStudentDal());
        public IActionResult Index()
        {
            var values = studentManager.TGetAll();
            return View(values);
        }
    }
}
