using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Model.MyModels.Error
{
    public class Error: BaseError
    {
        public Error(HttpStatusCode StatusCode, string message, string objectName)
            : base(StatusCode, message, objectName)
        {

        }


    }
}
