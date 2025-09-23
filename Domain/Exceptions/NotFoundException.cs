using Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message, 404, "NOT_FOUND")
        {
        }
        public NotFoundException(string message, System.Exception innerException) : base(message, 404, "NOT_FOUND", innerException)
        {
        }
    }
}
