using System;

namespace Opeqe.Sample.Common.Models
{
    public class ReturnValue
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
    public class ReturnValue<T>
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
