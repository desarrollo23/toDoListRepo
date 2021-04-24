using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.Base.Context;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.MyModels;
using ToDoList.Model.Repos;


namespace ToDoList.Infraestructure.Repos
{
    public class UserRepository: Repository.Repository<User> , IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork): base(unitOfWork)
        {

        }
    }
}
