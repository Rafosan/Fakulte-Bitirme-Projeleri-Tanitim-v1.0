using Microsoft.AspNetCore.Mvc;

namespace Fakultemiz_bitirme_projeleri_tanitim.ViewComponents.Admin
{
    public class AdminCategoryListView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
