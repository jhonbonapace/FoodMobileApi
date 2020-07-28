using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Application.Services;
using Domain.Entities;
using Domain.Helpers;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IUserService _userService;
        private readonly DatabaseContext _context;
        private readonly AppSettings _appSettings;

        public RegisterController(ILogger<RegisterController> logger, DatabaseContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings.Value;

            _userService = new UserService(_context, _appSettings);
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                return Ok(_userService.Add(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }
    }
}