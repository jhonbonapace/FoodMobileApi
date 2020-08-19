using System;
using System.Collections.Generic;
using Application.Attributes;
using Application.DTO;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, CustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost]
        // [Authorize]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add([FromForm] CustomerDto customerDto)
        {
            try
            {
                _customerService.Add(customerDto);

                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        // [HttpGet]
        // [Authorize]
        // [Route("List")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // public IActionResult List([FromQuery] CustomerListFilterDTO CustomerListFilterDto)
        // {
        //     try
        //     {
        //         IEnumerable<CustomerListResultDTO> result = _CustomerService.List(CustomerListFilterDto);

        //         return Ok(result);
        //     }
        //     catch (Exception ex)
        //     {
        //         _logger.LogError(ex, ex.Message);

        //         return StatusCode(500);
        //     }
        // }
    }
}