using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _cache;

        public ShoppingCarController(IShoppingCarService shoppingCarService, IMemoryCache cache)
        {
            _shoppingCarService = shoppingCarService;
            _cache = cache;
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

        [HttpGet("getById/{id}")]
        public IActionResult GetCartById(int id)
        {
            var response = _shoppingCarService.GetShoppingCartById(id);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("cache")]
        public IActionResult CacheTryGetValueSet()
        {
            DateTime cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
            {
                // Key not in cache, so get data.
                cacheEntry = DateTime.Now;

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(10));

                // Save data in cache.
                _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
            }

            return Ok(cacheEntry);
        }
    }

    public static class CacheKeys
    {
        public static string Entry { get { return "_Entry"; } }
        public static string CallbackEntry { get { return "_Callback"; } }
        public static string CallbackMessage { get { return "_CallbackMessage"; } }
        public static string Parent { get { return "_Parent"; } }
        public static string Child { get { return "_Child"; } }
        public static string DependentMessage { get { return "_DependentMessage"; } }
        public static string DependentCTS { get { return "_DependentCTS"; } }
        public static string Ticks { get { return "_Ticks"; } }
        public static string CancelMsg { get { return "_CancelMsg"; } }
        public static string CancelTokenSource { get { return "_CancelTokenSource"; } }
    }
}
