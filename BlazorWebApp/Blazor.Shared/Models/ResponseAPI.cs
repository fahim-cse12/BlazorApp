using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class ResponseAPI<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Value { get; set; }
    }
}
