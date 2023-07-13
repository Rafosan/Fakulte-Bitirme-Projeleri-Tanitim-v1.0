using EntityLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Category:BaseDateEntity
    {
        [Key]
        public int ID { get; set; }
        public Types Type { get; set; }
        public string Value { get; set; }
        public bool Status { get; set; }

        public enum Types
        {
            Yıl=1,
            Bölüm=2,
            Danışman=3
        }
    }
}
