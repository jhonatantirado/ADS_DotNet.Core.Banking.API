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
    using Microsoft.AspNetCore.Http;
    using Common.constantes;

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
                return Ok(_customerApplicationService.getById(CustomerId));
            }
            catch (Exception)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }

        }

        [HttpGet]
        public IActionResult Get(int offset, int limit)
        {
            try
            {
                return Ok(_customerApplicationService.getAll(offset, limit));
            }
            catch (Exception)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerDto customerDto)
        {
            try
            {
                _customerApplicationService.create(customerDto);
                return Ok(this.responseHandler.getOkCommandResponse("Customer created!", Constantes.HttpStatus.Created));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpPut("{CustomerId}")]
        public IActionResult Put([FromBody] CustomerDto customerDto, long CustomerId)
        {
            try
            {
                _customerApplicationService.update(customerDto, CustomerId);
                return Ok(this.responseHandler.getOkCommandResponse("Customer updated!", Constantes.HttpStatus.Success));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpDelete("{CustomerId}")]
        public IActionResult Delete(int CustomerId)
        {
            try
            {
                _customerApplicationService.deleted(CustomerId);
                return Ok(this.responseHandler.getOkCommandResponse("Bank Account deleted!", Constantes.HttpStatus.Success));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }
    }
}

