﻿using EntityLayer.Base;

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
        ElektrikElektronikMühendisliği = 11,
        MakineMühendisliği = 12,
        İnşaatMühendisliği=13,
        MekatronikMühendisliği = 14,
        BiyomedikalMühendisliği = 15,
        TemelBilimler =16,
        Diğer=17,
    }
}
