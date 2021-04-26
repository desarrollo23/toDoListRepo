using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS;
using ToDoList.Model.MyModels;
using ToDoList.Model.Repos;

namespace ToDoList.Infraestructure.Repos
{
    public class SecurityRepository : Repository.Repository<User>, ISecurityRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public SecurityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User AuthenticateUser(User user)
        {
            return _unitOfWork.Context.User
                 .FirstOrDefault(x => x.Identification == user.Identification && x.Password == user.Password);
        }
    }
}
