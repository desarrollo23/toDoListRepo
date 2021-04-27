using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Model.DTOS;
using ToDoList.Model.Services;

namespace ToDoList.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SecurityController : ControllerBase
    {
        private ISecurityService _securityService;
        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }


        [AllowAnonymous]
        //[JwtAuthentication]
        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] ValidateUserDTO validateUserDTO)
        {
            var user = _securityService.ValidateUser(validateUserDTO);

            if (user != null)
            {
                var token = _securityService.GenerateToken(user);

                var responseAuthenticateDTO = new ResponseAuthenticateDTO
                {
                    Identification = validateUserDTO.Identification,
                    Message = "Authentication successful",
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Token = token
                };


                return Ok(responseAuthenticateDTO);
            }


            return Unauthorized();

        }
    }
}
