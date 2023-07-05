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
    public class Project:BaseDateEntity
    {
        [Key]
        public int ProjectID { get; set; }
        public string Name { get; set; }
        public byte[] Image1 { get; set; }
        public byte[] Image2 { get; set; }
        public byte[] Image3 { get; set; }
        public byte[] Image4 { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int LikeCount { get; set; }
        public bool Status { get; set; }//

        public Student Student { get; set; }
        public Teacher Teacher { get; set;}
    }
}
