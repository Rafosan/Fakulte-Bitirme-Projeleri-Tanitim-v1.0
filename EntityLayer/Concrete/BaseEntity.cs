using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BaseEntity
    {
        public string NameAndSurname { get; set; }
        public string UserName { get; set;}
        public string Password { get; set;}
        public bool Status { get; set;}
    }
}
