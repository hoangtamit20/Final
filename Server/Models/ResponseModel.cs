using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel()
        {
        }

        public ResponseModel(T? data)
        {
            Success = true;
            Message = string.Empty;
            Error = null;
            Data = data;
        }

        public bool Success { get; set; }
        public string? Message { get; set; }
        public string[]? Error { get; set; }
        public T? Data { get; set; }
    }
}