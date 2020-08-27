using application.services;
using Application.Attributes;
using Application.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class CustomerController : ControllerBase
    {
        private readonly customerservice _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, customerservice customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpPost]
        [Authorize]
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

        [HttpGet]
        [Authorize]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult List([FromQuery] CustomerListFilterDto customerListFilterDto)
        {
            try
            {
                var result = _customerService.List(customerListFilterDto);

                return Ok(result);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        [HttpGet]
        // [Authorize]
        [Route("GetObject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetObject()
        {
            try
            {
                var customerDto = new CustomerDto();
              
                return Ok(customerDto);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                return StatusCode(500);
            }
        }

        //[HttpGet]
        //[Authorize]
        //[Route("List")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult List([FromQuery] CustomerListFilterDto CustomerListFilterDto)
        //{
        //    try
        //    {
        //        IEnumerable<CustomerListFilterDto> result = (IEnumerable<CustomerListFilterDto>)_customerService.List(CustomerListFilterDto);

        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message);

        //        return StatusCode(500);
        //    }
        //}
    }
}