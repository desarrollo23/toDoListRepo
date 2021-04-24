using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Infraestructure.Utils.Security;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.MyModels;
using ToDoList.Model.Repos;
using ToDoList.Model.Services;


namespace ToDoList.Infraestructure.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepo, IUnitOfWork unitOfWork)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
        }

        public void CreateUser(User user)
        {
            user.Password = Encrypt.EncryptPassword(user.Password);
            user.CreatedAt = DateTime.UtcNow;
            user.ModifiedAt = null;

            _userRepo.Add(user);
            _unitOfWork.Commit();
        }

        public IList<User> GetAllUsers()
        {
            return _userRepo.FindAll();
        }
    }
}
