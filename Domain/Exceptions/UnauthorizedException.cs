using Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(string message) : base(message, 401, "UNAUTHORIZED")
        {
        }
        public UnauthorizedException(string message, System.Exception innerException) : base(message, 401, "UNAUTHORIZED", innerException)
        {
        }
    }
}
