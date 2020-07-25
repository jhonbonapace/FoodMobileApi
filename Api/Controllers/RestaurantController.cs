using Application.Attributes;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantService _restaurantService;
        private readonly ILogger<RestaurantController> _logger;

        public RestaurantController(ILogger<RestaurantController> logger, RestaurantService restaurantService)
        {
            _logger = logger;
            _restaurantService = restaurantService;
        }

        [HttpPost]
        [Authorize]
        [Route("Add")]
        public IActionResult Add([FromForm] RestaurantDTO restaurantDto)
        {
            try
            {
                _restaurantService.Add(restaurantDto);

                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("List")]
        public IActionResult List([FromQuery] RestaurantListFilterDTO restaurantListFilterDto)
        {
            try
            {
                IEnumerable<RestaurantListResultDTO> result = _restaurantService.List(restaurantListFilterDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }           
        }
    }
}