using EntityLayer.Concrete;

namespace Fakultemiz_bitirme_projeleri_tanitim.Models.TeacherV
{
    public class TeacherIndexViewModel
    {
        public List<Project> Projeler { get; set; }
        public List<ProjectWithStudentInfo> ProjelerOgrenciBilgisi { get; set; }
    }
    public class ProjectWithStudentInfo
    {
        public Project Project { get; set; }
        public string OgrenciAdi { get; set; }
        public DepartmentCode OgrenciBolumKodu { get; set; }
    }
}
