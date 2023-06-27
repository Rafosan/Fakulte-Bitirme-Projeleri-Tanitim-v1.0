using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Teacher:BaseEntiy
    {
        public MajorScienceCode MajorScienceCode { get; set; }
        public List<Project> Projects { get; set; }
    }
    public enum MajorScienceCode
    {
        DonanimAnaBilimDali = 100,
        YazilimAnaBilimDali = 101,
        MekanikAnaBilimDali = 102
    }

}
