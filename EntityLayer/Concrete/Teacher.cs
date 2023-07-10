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
    public class Teacher:BaseEntiy
    {
        public MajorScienceCode MajorScienceCode { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
    public enum MajorScienceCode
    {
        Yazılım=1000,
        Donanım=1001,
        YapayZeka=1002,
        Termodinamik=1003,
    }
}
