using Application.Interface;
using Application.Services;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class LocationController : ControllerBase
    {

        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _ILocationService;
        private readonly DatabaseContext _context;

        public LocationController(ILogger<LocationController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
            _ILocationService = new LocationService(_context);
        }

        [HttpGet("Countries/List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListCountries()
        {
            try
            {
                return Ok(_ILocationService.GetCountries());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet("State/List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListStates(int IdCountry)
        {
            try
            {
                return Ok(_ILocationService.GetStates(IdCountry));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet("City/List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListCities(int IdState)
        {
            try
            {
                return Ok(_ILocationService.GetCities(IdState));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }
    }
}