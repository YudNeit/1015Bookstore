using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1015bookstore.viewmodel.Comon
{
    public class ResponseService<T> where T : class
    {
        public int CodeStatus { get; set; }
        public bool Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ResponseService()
        {
            Data = null;
        }

        public ResponseService(int codeStatus, bool status, string? message, T? data = null)
        {
            CodeStatus = codeStatus;
            Status = status;
            Message = message;
            Data = data;
        }
    }

    public class ResponseService : ResponseService<object>
    {
        public ResponseService()
        {
            
        }

        public ResponseService(int codeStatus, bool status, string? message, object? data = null)
            : base(codeStatus, status, message, data)
        {
            
        }
    }
}
