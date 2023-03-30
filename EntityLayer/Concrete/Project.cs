using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public DateTime CreationTime { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }//
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set;}
    }
}
