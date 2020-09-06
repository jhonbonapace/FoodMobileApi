using Application.DTO;
using Application.Interface;
using Application.Services;
using AutoMapper;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class RecoveryController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DatabaseContext _context;
        private readonly IRecoveryService _service;
        private readonly ILogger<RecoveryController> _logger;

        public RecoveryController(ILogger<RecoveryController> logger, DatabaseContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _service = new RecoveryService(_context, _mapper);
        }

        [HttpPost("Password/Recovery")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PasswordRecovery([FromBody] PasswordRecoveryDTO recovery)
        {
            try
            {
                var response = _service.Add(recovery.Email);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("Password/{IdRecovery}/{Email}/{Hash}")]
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
    }
}
