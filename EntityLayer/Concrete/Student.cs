using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public List<Project> Projects { get; set; }
    }
    public enum DepartmentCode
    {
        BilgisayarMühendsliği = 10,
        ElektrikElektronikMühendisliği = 11,
        BiyomedikalMühendisliği = 12,
        MakineMühendisliği = 13,
        İnşaatMühendisliği = 14,
        MekatronikMühendisliği = 15,
        TemelBilimler=16,
    }
}
