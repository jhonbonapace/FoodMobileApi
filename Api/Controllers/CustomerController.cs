using System;
using System.Collections.Generic;
using Application.Attributes;
using Application.DTO;
using Application.Services;
using AutoMapper;
using Domain.Entities;
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
        private readonly IMapper _mapper;

        public CustomerController(ILogger<CustomerController> logger, CustomerService customerService, IMapper mapper)
        {
            _logger = logger;
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpPost]
        //[Authorize]
        [Route("Add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Add([FromForm] CustomerDto customerDto)
        {
            try
            {
                _customerService.Add(_mapper.Map<Customer>(customerDto));

                return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        //[Authorize]
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

                return StatusCode(StatusCodes.Status500InternalServerError);
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

                return StatusCode(StatusCodes.Status500InternalServerError);
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