using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.MyModels.Error
{
    public class BaseError
    {
        public BaseError(HttpStatusCode StatusCode, string message, string objectName)
        {
            this.StatusCode = StatusCode;
            Message = message;
            ObjectName = objectName;
        }
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string ObjectName { get; set; }
    }
}
