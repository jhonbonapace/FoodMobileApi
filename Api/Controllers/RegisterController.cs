using Application.DTO.Auth;
using Application.Interface;
using Application.Services;
using Domain.Entities;
using Domain.Helpers;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IUserService _userService;
        private readonly DatabaseContext _context;
        private readonly IOptions<AppSettings> _appSettings;

        public RegisterController(ILogger<RegisterController> logger, DatabaseContext context, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings;

            _userService = new UserService(_context, _appSettings.Value);
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] User user)
        {
            try
            {
                var response = _userService.Add(user);


                if (!response.Response.Success)
                    return Ok(response);
                else
                {
                    IAuthService authService = new AuthService(_appSettings, _context);

                    var auth = new AuthenticateRequest() { Email = user.Email };

                    var registrationResponse = authService.Authenticate(auth, true);

                    return Ok(registrationResponse);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }
    }
}