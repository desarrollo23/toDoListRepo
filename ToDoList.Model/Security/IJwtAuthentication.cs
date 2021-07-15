using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.DTOS;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Security
{
    public interface IJwtAuthentication
    {
        void GenerateJSONWebToken(ResponseAuthenticateDTO userInfo);
    }
}
