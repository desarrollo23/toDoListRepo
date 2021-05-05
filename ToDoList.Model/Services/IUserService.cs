using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.DTOS;
using ToDoList.Model.DTOS.Response.Base;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Services
{
    public interface IUserService
    {
        EntityResponse CreateUser(CreateUserDTO userDTO);
        IList<User> GetAllUsers();
    }
}
