
namespace Account.Api
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using Account.Application.Dto;
    using Common.Application.Dto;
    using Common.Api.Controller;
    using Account.Application;


    [Route("api/[controller]")]
    public class AccountController
    {
        IAccountApplicationService _accountApplicationService;
        ResponseHandler responseHandler;

        public AccountController(IAccountApplicationService accountApplicationService)
        {
            _accountApplicationService = accountApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpGet]
        public string Get()
        {
            return "Hola Mundo";
        }


        [HttpPost]
        public ResponseDto Post([FromBody] BankAccountDto bankAccountDto)
        {
            try
            {
                _accountApplicationService.create(bankAccountDto);
                return this.responseHandler.getOkCommandResponse("Bank Account created!");
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

        [HttpPut]
        public ResponseDto Put([FromBody] BankAccountDto bankAccountDto)
        {
            try
            {
                _accountApplicationService.update(bankAccountDto);
                return this.responseHandler.getOkCommandResponse("Bank Account created!");
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

        [HttpDelete]
        public ResponseDto Delete(int Id)
        {
            try
            {
                _accountApplicationService.lockAccount(Id);
                return this.responseHandler.getOkCommandResponse("Bank Account created!");
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
