﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Infraestructure.Utils.Security;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS;
using ToDoList.Model.MyModels;
using ToDoList.Model.Repos;
using ToDoList.Model.Security;
using ToDoList.Model.Services;

namespace ToDoList.Infraestructure.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtAuthentication _jwtAuthentication;
        private readonly IMapper _mapper;


        public SecurityService(
            ISecurityRepository securityRepository, 
            IUnitOfWork unitOfWork,
            IJwtAuthentication jwtAuthentication,
            IMapper mapper)
        {
            _securityRepository = securityRepository;
            _unitOfWork = unitOfWork;
            _jwtAuthentication = jwtAuthentication;
            _mapper = mapper;
        }

        public string GenerateToken(User userInfo)
        {
            return _jwtAuthentication.GenerateJSONWebToken(userInfo);
        }

        public User ValidateUser(ValidateUserDTO userDTO)
        {
            var userReq = _mapper.Map<User>(userDTO);
            userReq.Password = Encrypt.EncryptPassword(userDTO.Password);

            var user = _securityRepository.AuthenticateUser(userReq);

            return user ?? null;
        }
    }
}