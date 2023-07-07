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
        BilgisayarBilimleri = 1000,
        Donanım = 1001,
        Yazılım = 1002,
        YapayZeka = 1003,
        TarımPolitikasıveYayım = 1004,
        EndüstriBitkileri = 1005,
        Mekanik = 1006,
        YapımYönetimi = 1007,
        Yapı = 1008,
        Termodinamik = 1009,
        Konstrüksiyonveİmalat = 1010,
        YapıMalzemeleri = 1011,
        Ulaştırma = 1012,
        Hidrolik = 1013,
        Geoteknik = 1014,
        Hastalıklar = 1015,
        OrmanBotaniği = 1016,
        GeodeziveFotogrametre = 1017,
        MakineMalzemeleriveİmalatTeknolojileri = 1018,
        DenizBiyolojisi = 1019,
        HavzaYönetimi = 1020,
        Diğer = 1021,
    }
}
