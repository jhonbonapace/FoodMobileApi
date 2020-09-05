using Application.DTO;
using Application.Interface;
using Application.Services;
using AutoMapper;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class FavoriteCustomersController : ControllerBase
    {
        private IMapper _mapper;
        private readonly ILogger<LocationController> _logger;
        private readonly IFavoriteCustomersService _service;
        private readonly DatabaseContext _context;

        public FavoriteCustomersController(ILogger<LocationController> logger, DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _logger = logger;
            _context = context;
            _service = new FavoriteCustomersService(_context, _mapper);
        }

        [HttpPost("Favorite/Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddFavoriteCustomer([FromBody] UserFavoriteCustomerDTO item)
        {
            try
            {
                UserDTO user = (UserDTO)HttpContext.Items["User"];
                item.UserId = user.Id;

                var response =  _service.Add(item);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet("Favorite/List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ListFavoriteCustomers()
        {
            try
            {
                UserDTO user = (UserDTO)HttpContext.Items["User"];

                var response =  _service.List(user.Id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [HttpDelete("Favorite/Delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteFavoriteCustomer([FromQuery] int Id)
        {
            try
            {
                var response = _service.Delete(Id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }
    }
}