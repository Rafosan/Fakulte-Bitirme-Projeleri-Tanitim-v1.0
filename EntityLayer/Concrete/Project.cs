using EntityLayer.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Project:BaseDateEntity
    {
        [Key]
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public byte[]? Image1 { get; set; }
        public byte[]? Image2 { get; set; }
        public byte[]? Image3 { get; set; }
        public byte[]? Image4 { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int LikeCount { get; set; }
        public bool Status { get; set; }//

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set;}
    }
}
