
namespace BankAccount.Api
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using BankAccount.Application.Dto;
    using Common.Application.Dto;
    using Common.Api.Controller;
    using BankAccount.Application;


    [Route("api/[controller]")]
    public class BankAccountController
    {
        IBankAccountApplicationService _bankAccountApplicationService;
        ResponseHandler responseHandler;

        public BankAccountController(IBankAccountApplicationService bankAccountApplicationService)
        {
            _bankAccountApplicationService = bankAccountApplicationService;
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
                _bankAccountApplicationService.create(bankAccountDto);
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
                _bankAccountApplicationService.update(bankAccountDto);
                return this.responseHandler.getOkCommandResponse("Bank Account updated!");
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
                _bankAccountApplicationService.lockAccount(Id);
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
