using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.ViewComponents.Teacher
{
    public class TeacherProjectView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
