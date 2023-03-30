using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Teacher:BaseEntity
    {
        [Key]
        public int TeacherID { get; set; }
        public int MajorScienceCode { get; set; }
        public List<Project> Projects { get; set; }
    }
}
