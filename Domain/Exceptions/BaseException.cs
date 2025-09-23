using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exception
{
    public abstract class BaseException : System.Exception
    {
        public int StatusCode { get; }
        public string ErrorCode { get; }

        protected BaseException(string message, int statusCode, string errorCode = null)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode ?? statusCode.ToString();
        }

        protected BaseException(string message, int statusCode, string errorCode, System.Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode ?? statusCode.ToString();
        }
    }
}
