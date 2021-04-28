using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.MyModels.Error;

namespace ToDoList.Model.DTOS.Response.Base
{
    public class EntityResponse
    {
        public EntityResponse()
        {
            Errors = new List<Error>();
        }
        public object? Entity { get; set; }
        public HttpStatusCode? StatusCode { get; set; }
        public List<Error> ? Errors { get; set; }
    }
}
