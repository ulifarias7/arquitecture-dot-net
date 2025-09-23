using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ResponseObjectJson
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object? Responses { get; set; }
    }
}
