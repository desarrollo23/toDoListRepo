using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.DTOS;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Services
{
    public interface ISecurityService
    {
        ResponseAuthenticateDTO ValidateUser(ValidateUserDTO userDTO);
        void GenerateToken(ResponseAuthenticateDTO userInfo);
    }
}
