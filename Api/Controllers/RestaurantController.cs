using System.Collections.Generic;
using System.IO;
using Application.Attributes;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantService _restaurantService;

        public RestaurantController(RestaurantService restaurantService) => _restaurantService = restaurantService;

        [HttpPost]
        [Authorize]
        [Route("Add")]  
        public IActionResult Add([FromForm] RestaurantDTO restaurantDto)
        {
            _restaurantService.Add(restaurantDto);

            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("List")]     
        public IActionResult List([FromQuery] RestaurantListFilterDTO restaurantListFilterDto)
        {
            IEnumerable<RestaurantListResultDTO> result = _restaurantService.List(restaurantListFilterDto);

            return Ok(result);
        }
    }
}