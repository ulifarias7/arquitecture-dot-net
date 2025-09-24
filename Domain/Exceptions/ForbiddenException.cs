using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base("ForbiddenException")
        {
        }
        public ForbiddenException(string name) : base(name)
        {
        }
    }
}
