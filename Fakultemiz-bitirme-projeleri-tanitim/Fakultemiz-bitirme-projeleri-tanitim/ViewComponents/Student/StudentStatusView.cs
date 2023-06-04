using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.ViewComponents.Student
{
    public class StudentStatusView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
