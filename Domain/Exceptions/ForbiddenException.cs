using Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(string message) : base(message, 403, "FORBIDDEN")
        {
        }
        public ForbiddenException(string message, System.Exception innerException) : base(message, 403, "FORBIDDEN", innerException)
        {
        }
    }
}
