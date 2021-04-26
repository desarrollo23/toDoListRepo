using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Security
{
    public interface IJwtAuthentication
    {
        string GenerateJSONWebToken(User userInfo);
    }
}
