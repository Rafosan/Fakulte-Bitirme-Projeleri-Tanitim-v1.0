using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Student:BaseEntity
    {
        [Key]
        public int StudentID { get; set; }
        public int DepartmentCode { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
