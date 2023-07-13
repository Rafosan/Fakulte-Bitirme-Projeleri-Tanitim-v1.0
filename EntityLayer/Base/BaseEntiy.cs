using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Base
{
    public abstract class BaseEntiy:BaseDateEntity
    {
        [Key]
        public int ID { get; set; }
        public string NameAndSurname { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
