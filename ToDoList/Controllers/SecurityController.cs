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
        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] ValidateUserDTO validateUserDTO)
        {
            
            var user = _securityService.ValidateUser(validateUserDTO);

            if (user != null)
                return Ok(user);

            return Unauthorized("User not authenticated");

        }
    }
}
