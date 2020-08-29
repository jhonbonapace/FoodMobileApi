using Application.DTO;
using Application.Interface;
using Application.Services;
using Domain.Entities;
using Domain.Helpers;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class LocationController : ControllerBase
    {

        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<LocationController> _logger;
        private readonly ILocationService _ILocationService;
        private readonly DatabaseContext _context;
        private readonly MapBoxSettings _mapboxSettings;

        public LocationController(ILogger<LocationController> logger, DatabaseContext context, IOptions<MapBoxSettings> mapboxSettings, IMemoryCache memoryCache)
        {
            _logger = logger;
            _context = context;
            _mapboxSettings = mapboxSettings.Value;
            _memoryCache = memoryCache;
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

        [HttpGet("Countries/List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListCountries()
        {
            try
            {
                ResponseModel<IEnumerable<Country>> countries;

                if (_memoryCache.TryGetValue("countries", out countries))
                {
                    return Ok(countries);
                }
                else
                {
                    var response = _ILocationService.GetCountries();

                    _memoryCache.Set("countries", response);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet("State/List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListStates()
        {
            try
            {
                //Brazil
                var IdCountry = 1;

                ResponseModel<IEnumerable<State>> states;

                if (_memoryCache.TryGetValue("states", out states))
                {
                    return Ok(states);
                }
                else
                {
                    var response = _ILocationService.GetStates(IdCountry);

                    _memoryCache.Set("states", response);

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

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