using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Model.Base.Interfaces.Repository;
using ToDoList.Model.DTOS;
using ToDoList.Model.Services;

namespace ToDoList.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ShoppingCarController : ControllerBase
    {
        private readonly IShoppingCarService _shoppingCarService;

        public ShoppingCarController(IShoppingCarService shoppingCarService)
        {
            _shoppingCarService = shoppingCarService;
        }

        /// <summary>
        /// Create a new shopping car
        /// </summary>
        /// <param name="shoppingCar"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public IActionResult Create([FromBody] ShoppingCarDTO shoppingCar)
        {
            var response = _shoppingCarService.CreateShoppingCar(shoppingCar);
            return Ok(response);
        }

        [HttpGet("getShoppingCars/{userId}")]
        public IActionResult GetAllShoppingCars([FromRoute] int userId)
        {
            var response = _shoppingCarService.GetShoppingCarsByIdUser(userId);

            if (response.Errors.Any())
                return NoContent();

            return Ok(response);
        }

        [HttpPut("updateShoppingCar/{id}")]
        public IActionResult UpdateShoppingCar(ShoppingCarDTO shoppingCarDTO, int id)
        {
            var response = _shoppingCarService.UpdateShoppingCar(shoppingCarDTO, id);
            return Ok(response);
        }

        [HttpDelete("deleteShoppingCar/{id}")]
        public IActionResult DeleteShoppingCar(int id)
        {
            var response = _shoppingCarService.DeleteShoppingCar(id);
            return Ok(response);
        }
    }
}
