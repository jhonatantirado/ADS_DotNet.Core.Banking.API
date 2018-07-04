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
    public class CustomerController
    {

        ICustomerApplicationService _customerApplicationService;
        ResponseHandler responseHandler;

        public CustomerController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpGet("{CustomerId}")]
        public CustomerDto Get(long CustomerId)
        {
            return _customerApplicationService.getById(CustomerId);
        }

        [HttpGet]
        public GridDto Get(int offset, int limit )
        {
            return _customerApplicationService.getAll(offset, limit);
        }

        [HttpPost]
        public ResponseDto Post([FromBody] CustomerDto customerDto)
        {
            try
            {
                _customerApplicationService.create(customerDto);
                return this.responseHandler.getOkCommandResponse("Customer created!");
            }
            catch (ArgumentException ex)
            {
                return this.responseHandler.getAppCustomErrorResponse(ex.Message);
            }
            catch (Exception ex)
            {
                return this.responseHandler.getAppExceptionResponse();
            }
        }

        [HttpPut("{CustomerId}")]
        public ResponseDto Put([FromBody] CustomerDto customerDto, long CustomerId)
        {
            try
            {
                _customerApplicationService.update(customerDto, CustomerId);
                return this.responseHandler.getOkCommandResponse("Customer updated!");
            }
            catch (ArgumentException ex)
            {
                return this.responseHandler.getAppCustomErrorResponse(ex.Message);
            }
            catch (Exception ex)
            {
                return this.responseHandler.getAppExceptionResponse();
            }
        }

        [HttpDelete("{CustomerId}")]
        public ResponseDto Delete(int CustomerId)
        {
            try
            {
                _customerApplicationService.deleted(CustomerId);
                return this.responseHandler.getOkCommandResponse("Bank Account deleted!");
            }
            catch (ArgumentException ex)
            {
                return this.responseHandler.getAppCustomErrorResponse(ex.Message);
            }
            catch (Exception ex)
            {
                return this.responseHandler.getAppExceptionResponse();
            }
        }
    }
}

