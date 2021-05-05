using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Infraestructure.Utils.Security;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS;
using ToDoList.Model.DTOS.Response.Base;
using ToDoList.Model.MyModels;
using ToDoList.Model.MyModels.Error;
using ToDoList.Model.Repos;
using ToDoList.Model.Services;


namespace ToDoList.Infraestructure.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(
            IUserRepository userRepo, 
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _userRepo = userRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public EntityResponse CreateUser(CreateUserDTO userDTO)
        {
            var response = new EntityResponse(); ;

            try
            {

                var userExist = _userRepo.FindBy(x => x.Identification == userDTO.Identification);

                if(userExist != null)
                {
                    response.Errors.Add
                            (
                            new Error(System.Net.HttpStatusCode.BadRequest, 
                            "UserService",
                            "User with the same identification exist")
                            );

                    return response;
                }

                var user = _mapper.Map<User>(userDTO);

                user.Password = Encrypt.EncryptPassword(user.Password);
                user.CreatedAt = DateTime.UtcNow;
                user.ModifiedAt = null;

                _userRepo.Add(user);
                _unitOfWork.Commit();

                response.Entity = userDTO;
                response.StatusCode = System.Net.HttpStatusCode.Created;
            }
            catch (Exception)
            {
                response.Errors.Add
                           (
                           new Error(System.Net.HttpStatusCode.InternalServerError,
                           null,
                           string.Empty)
                           );
            }

            return response;
        }

        public IList<User> GetAllUsers()
        {
            return _userRepo.FindAll();
        }
    }
}
