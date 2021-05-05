using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.DTOS.Base;

namespace ToDoList.Model.DTOS
{
    public class ResponseAuthenticateDTO: ResponseBaseDTO
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string Token { get; set; }
    }
}
