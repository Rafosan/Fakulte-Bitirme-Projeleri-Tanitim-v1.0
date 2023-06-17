using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.ViewComponents.Student
{
    public class StudentInformationView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
