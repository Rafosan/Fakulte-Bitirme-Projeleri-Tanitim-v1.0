using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.Controllers
{
    public class StudentController : Controller
    {
        //StudentManager studentManager=new StudentManager(new EfStudentDal());
        StudentManager studentManager;
        public StudentController(EfStudentDal efStudentDal)
        {
            this.studentManager = studentManager;
        }
        public IActionResult Index()
        {
            var values = studentManager.TGetAll();
            return View(values);
        }
    }
}
