using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.ViewComponents.Teacher
{
    public class TeacherStudentView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
