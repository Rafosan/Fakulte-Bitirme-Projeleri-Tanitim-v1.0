using EntityLayer.Concrete;
using X.PagedList;

namespace Fakultemiz_bitirme_projeleri_tanitim.Models.HomeV
{
    public class HomeViewModel
    {
        public IPagedList<Project> Projeler { get; set; }
        public IEnumerable<Category> Yillar { get; set; }
        public IEnumerable<Category> Bolumler { get; set; }
        public IEnumerable<Category> Danismanlar { get; set; }
    }
}
