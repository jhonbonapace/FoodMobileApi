using Application.Attributes;
using Application.Interface;
using Application.Services;
using Domain.Helpers;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class LocationController : ControllerBase
    {

        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _ILocationService;
        private readonly DatabaseContext _context;
        private readonly MapBoxSettings _mapboxSettings;

        public LocationController(ILogger<LocationController> logger, DatabaseContext context, IOptions<MapBoxSettings> mapboxSettings)
        {
            _logger = logger;
            _context = context;
            _mapboxSettings = mapboxSettings.Value;
            _ILocationService = new LocationService(_context, _mapboxSettings);
        }



        [HttpGet("Location/Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> LocationSearch([FromQuery] string location)
        {
            try
            {
                var response = await _ILocationService.SearchLocation(location);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("State/List/{IdCountry}")]
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

        [Authorize]
        [HttpGet("City/List/{IdState}")]
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