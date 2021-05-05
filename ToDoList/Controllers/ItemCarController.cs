using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Model.DTOS;
using ToDoList.Model.Services;

namespace ToDoList.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ItemCarController : ControllerBase
    {
        private readonly IItemCarService _itemCarService;
        public ItemCarController(IItemCarService itemCarService)
        {
            _itemCarService = itemCarService;
        }

        [HttpPost("create")]
        public IActionResult Create(ItemCarDTO itemCarDTO)
        {
            var response = _itemCarService.CreateItem(itemCarDTO);
            return Ok(response);
        }

        [HttpPut("updateStateItem/{id}")]
        public IActionResult ChangeStateItem([FromBody] ItemCarDTO itemCarDTO, int id)
        {
            var response = _itemCarService.ChangeStateItem(itemCarDTO, id);


            return Ok(response);
        }

        [HttpPut("updateItem/{id}")]
        public IActionResult UpdateItem(ItemCarDTO itemCarDTO, int id)
        {
            var response = _itemCarService.UpdateItem(itemCarDTO, id);
            return Ok(response);
        }

        [HttpDelete("deleteItem/{id}")]
        public IActionResult DeleteItem(int id)
        {
            var response = _itemCarService.DeleteItem(id);
            return Ok(response);
        }
    }
}
