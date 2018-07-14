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
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
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
        public IActionResult Get(int offset = Constantes.DefaultPagination.defaultOffset, int limit = Constantes.DefaultPagination.defaultLimit, string orderBy = Constantes.DefaultPagination.orderBy, string orderDirection = Constantes.DefaultPagination.orderDirection)
        {
            try
            {
                return Ok(_customerApplicationService.getAll(offset, limit, orderBy,  orderDirection ));
            }
            catch (Exception)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }

        [Route("/api/Customers/findByDocumentNumber")]
        [HttpGet]
        public IActionResult  findByDocumentNumber(string documentNumber)
        {
            try
            {
                return Ok(_customerApplicationService.findByDocumentNumber(documentNumber));
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
                return Ok(this.responseHandler.getOkCommandResponse("Customer deleted!", Constantes.HttpStatus.Success));
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

