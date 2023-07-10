using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Student : BaseEntiy
    {
        public DepartmentCode DepartmentCode { get; set; }
        public string? EMail { get; set; }
        public string? Number { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
    public enum DepartmentCode
    {
        BilgisayarMühendsliği = 10,
        ElektrikElektronikMühendisliği=11,
        MakineMühendisliği=12,
        MakineveİmalatMühendisliği=13,
        MekatronikMühendisliği=14,
        İnşaatMühendisliği=15,
        İmalatMühendisliği=16,
        EnerjiSistemleriMühendisliği=17,
        Diğer=18,
    }
}
