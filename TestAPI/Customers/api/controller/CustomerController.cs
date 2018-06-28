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
    using Common.infrastructure.repository;

    [Route("api/[controller]")]
    public class CustomerController
    {

        CustomerApplicationService customerApplicationService;
        ResponseHandler responseHandler;
        private readonly IMapper _mapper;

        public CustomerController(BankingContext dbContext, IMapper mapper)
        {
            customerApplicationService = new CustomerApplicationService(dbContext, mapper);
            responseHandler = new ResponseHandler();
            _mapper = mapper;
        }

        [HttpPost]
        [Route("performCreate")]
        public ResponseDto performCreate([FromBody] CustomerDto customerDto)
        {
            try
            {
                customerApplicationService.performCreate(customerDto);
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

