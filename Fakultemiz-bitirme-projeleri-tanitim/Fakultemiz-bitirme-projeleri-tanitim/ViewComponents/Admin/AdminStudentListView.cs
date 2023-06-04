using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.ViewComponents.Admin
{
    public class AdminStudentListView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
