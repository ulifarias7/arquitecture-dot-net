using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class BaseEntity
    {
        public int id { get; set; }
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }
    }
}
