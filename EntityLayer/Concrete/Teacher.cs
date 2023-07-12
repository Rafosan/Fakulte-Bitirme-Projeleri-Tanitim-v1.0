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
        BilgisayarBilimleri=1000,
        BilgisayarDonanımı=1001,
        BilgisayarYazılımı=1002,
        YapayZeka =1003,
        Biyomedikal=1004,
        ElektrikElektronik=1005,
        Makine=1006,
        Hidrolik=1007,
        Ulaştırma=1008,
        YapıMalzemeleri=1009,
        Yapı=1010,
        Mekanik=1011,
        YapımYönetimi=1012,
        Geoteknik=1013,
        Mekatronik=1014,
        TemelBilimler=1015,
        Diğer=1016,
    }
}
