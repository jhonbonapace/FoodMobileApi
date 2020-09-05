using Application.DTO;
using Application.DTO.Auth;
using Application.Interface;
using Application.Services;
using AutoMapper;
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
        private IMapper _mapper;

        public RegisterController(ILogger<RegisterController> logger, DatabaseContext context, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _appSettings = appSettings;
            _mapper = mapper;

            _userService = new UserService(_context, _mapper, _appSettings.Value);
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] UserDTO user)
        {
            try
            {
                var remoteIpAddress = HttpContext.Connection.RemoteIpAddress;
                user.Ip = remoteIpAddress.ToString();

                var response = _userService.Add(user);

                if (!response.Response.Success)
                    return BadRequest(response);
                else
                {
                    IAuthService authService = new AuthService(_appSettings, _context, _mapper);

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