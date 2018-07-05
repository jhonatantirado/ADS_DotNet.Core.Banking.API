namespace Customer.Api
{
    using Customer.Application;
    using Customer.Application.Dto;
    using Common.Application;
    using Common.Application.Dto;
    using Common.Api.Controller;
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Common.Infrastructure.Repository;
    using System.Collections;
    using System.Collections.Generic;

    [Route("api/Customers/customer")]
    public class CustomerController : Controller
    {

        ICustomerApplicationService _customerApplicationService;
        ResponseHandler responseHandler;

        public CustomerController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpGet("{CustomerId}")]
        public IActionResult Get(long CustomerId)
        {
            try
            {
                return Created( nameof(Get), _customerApplicationService.getById(CustomerId));
            }
            catch (Exception)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }

        }

        [HttpGet]
        public IActionResult Get(int offset, int limit)
        {
            try
            {
                return Created(nameof(Get), _customerApplicationService.getAll(offset, limit));
            }
            catch (Exception)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customerDto)
        {
            try
            {
                _customerApplicationService.create(customerDto);
                return Created(nameof(Post), this.responseHandler.getOkCommandResponse("Customer created!"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpPut("{CustomerId}")]
        public IActionResult Put([FromBody] CustomerDto customerDto, long CustomerId)
        {
            try
            {
                _customerApplicationService.update(customerDto, CustomerId);
                return Created(nameof(Put), this.responseHandler.getOkCommandResponse("Customer updated!"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpDelete("{CustomerId}")]
        public IActionResult Delete(int CustomerId)
        {
            try
            {
                _customerApplicationService.deleted(CustomerId);
                return Created(nameof(Delete), this.responseHandler.getOkCommandResponse("Bank Account deleted!"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }
        }
    }
}

