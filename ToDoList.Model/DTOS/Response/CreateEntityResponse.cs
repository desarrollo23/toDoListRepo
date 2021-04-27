using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Model.DTOS.Response.Base;
using ToDoList.Model.MyModels.Error;

namespace ToDoList.Model.DTOS.Response
{
    public class CreateEntityResponse: EntityResponse
    {
        public string Message { get; set; }
    }
}
