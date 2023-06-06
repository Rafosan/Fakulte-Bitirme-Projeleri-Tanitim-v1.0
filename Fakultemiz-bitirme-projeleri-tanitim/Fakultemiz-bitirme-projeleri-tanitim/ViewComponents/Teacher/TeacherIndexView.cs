using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.ViewComponents.Teacher
{
    public class TeacherIndexView:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.i=id;
            return View();
        }
    }
}
