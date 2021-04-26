using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ToDoList.Model.DTOS.Base
{
    public class ResponseBaseDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }
}
