using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS;
using ToDoList.Model.MyModels;

namespace ToDoList.Model.Repos
{
    public interface ISecurityRepository: IRepository<User>
    {
        User AuthenticateUser(User user);
    }
}
