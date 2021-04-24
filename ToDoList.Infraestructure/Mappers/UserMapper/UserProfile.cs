using AutoMapper;
using ToDoList.Model;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Model.DTOS;
using ToDoList.Model.MyModels;

namespace ToDoList.Infraestructure.Mappers.UserMapper
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
