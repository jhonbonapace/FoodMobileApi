using Application.DTO.Auth;
using Application.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Api.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMapper _mapper;
        private IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger, IAuthService authService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
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

                if (!response.Success)
                    return Unauthorized(response);

                _logger.LogInformation($"Acesso concedido a {response.Data.Name}");


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
