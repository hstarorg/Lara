using System;

namespace SampleApp1.Models
{
    public class BusinessException : Exception
    {
        public BusinessException(string message, int statusCode = 400, string bizCode = null) : base(message)
        {
            StatusCode = statusCode;
            BusinessCode = bizCode;
        }

        public int StatusCode { get; set; }

        public string BusinessCode { get; set; }
    }
}
