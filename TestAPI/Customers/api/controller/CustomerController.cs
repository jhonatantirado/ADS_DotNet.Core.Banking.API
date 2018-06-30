namespace Customer.Api
{
    using Customer.Application;
    using Customer.Application.Dto;
    using Common.Application;
    using Common.Application.Dto;
    using Common.Api.Controller;
    using System;
    using Microsoft.AspNetCore.Mvc;
    using AutoMapper;
    using Common.Infrastructure.Repository;

    [Route("api/[controller]")]
    public class CustomerController
    {

        ICustomerApplicationService _customerApplicationService;
        ResponseHandler responseHandler;

        public CustomerController(ICustomerApplicationService customerApplicationService )
        {
            _customerApplicationService = customerApplicationService;
            responseHandler = new ResponseHandler();
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

        //[HttpGet]
        //public CustomerDto Get([FromBody] CustomerDto customerDto)
        //{
        //    //CustomerDto customerDto = new CustomerDto();
        //    customerDto.setFirstName("CCC");
        //    customerDto.setLastName("DDD");
        //    return customerDto;
        //    //return "Hola Mundo";
        //}
    }
}

