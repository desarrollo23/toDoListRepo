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
       

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet("getAllUsers")]
        //public IActionResult GetAllUsers()
        //{
        //    var users = _userService.GetAllUsers();

        //    var usersDTO = _mapper.Map<List<UserDTO>>(users);

        //    return Ok(usersDTO);
        //}

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult CreateUser(CreateUserDTO userDTO)
        {
            
            var response = _userService.CreateUser(userDTO);

            return Ok(response);
        }
    }
}
