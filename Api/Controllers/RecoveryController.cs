using Application.DTO;
using Application.Interface;
using Application.Services;
using AutoMapper;
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
    public class RecoveryController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly IRecoveryService _service;
        private readonly IOptions<AppSettings> _appSettings;
        private readonly ILogger<RecoveryController> _logger;

        public RecoveryController(ILogger<RecoveryController> logger, IOptions<AppSettings> appSettings, DatabaseContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings;
            _service = new RecoveryService(_context, _mapper, _appSettings.Value);
        }
        /// <summary>
        /// Used when the user put their email to recover the password
        /// </summary>
        /// <param name="recovery"></param>
        /// <returns></returns>
        [HttpPost("Password/Recovery")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PasswordRecoveryRequest([FromBody] string Email)
        {
            try
            {
                var response = _service.Add(Email);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Used to create a verification before receive a post with changed password
        /// </summary>
        /// <param name="IdRecovery"></param>
        /// <param name="Hash"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        [HttpGet("Verify/{IdRecovery}/{Email}/{Hash}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PasswordRecoveryVerify([FromQuery] int IdRecovery, string Hash, string Email)
        {
            try
            {
                var response = _service.Get(IdRecovery, Email, Hash);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Password/Change")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PasswordRecoveryChange([FromBody] PasswordRecoveryDTO recovery)
        {
            try
            {
                var response = _service.ChangePassword(recovery);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
