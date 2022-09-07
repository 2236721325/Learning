using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpDDDLearn.Domain.Shared
{
    public class ApiResult<T>
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        public T? Result { get; set; }
    }
    public class ApiResult
    {
        public string? Message { get; set; }
        public bool Status { get; set; }
        //public object? Result { get; set; }
    }
}
