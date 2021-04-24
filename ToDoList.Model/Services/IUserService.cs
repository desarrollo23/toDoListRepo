using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        IList<User> GetAllUsers();
    }
}
