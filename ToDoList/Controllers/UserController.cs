using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Infraestructure.Utils.Security;
using ToDoList.Model.DTOS;
using ToDoList.Model.MyModels;
using ToDoList.Model.Services;

namespace ToDoList.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            var usersDTO = _mapper.Map<List<UserDTO>>(users);

            return Ok(usersDTO);
        }

        [HttpPost("create")]
        public IActionResult CreateUser(CreateUserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            _userService.CreateUser(user);

            return Ok();
        }
    }
}
