using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Base
{
    public abstract class BaseDateEntity
    {
        public DateTime? CreationTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
