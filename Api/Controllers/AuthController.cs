using Application.DTO.Auth;
using Application.Interface;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;

namespace Api.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }


        [HttpPost("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            try
            {

                var response = _authService.Authenticate(model);

                if (!response.Response.Success)
                    return Unauthorized(response.Response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return Unauthorized();
        }

       
    }
}
