
namespace BankAccount.Api
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using BankAccount.Application.Dto;
    using Common.Application.Dto;
    using Common.Api.Controller;
    using BankAccount.Application;


    //[Route("api/[controller]")]
    [Route("api/Accounts")]
    public class BankAccountController
    {
        IBankAccountApplicationService _bankAccountApplicationService;
        ResponseHandler responseHandler;

        public BankAccountController(IBankAccountApplicationService bankAccountApplicationService)
        {
            _bankAccountApplicationService = bankAccountApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpGet("{AccountId}")]
        public  BankAccountDto Get(long AccountId)
        {
            return _bankAccountApplicationService.getById(AccountId);
        }

        [HttpGet]
        public GridDto Get(int offset, int limit)
        {
            return _bankAccountApplicationService.getAll(offset, limit);
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

        [HttpPut("{AcccountId}")]
        public ResponseDto Put([FromBody] BankAccountDto bankAccountDto , long AcccountId)
        {
            try
            {
                _bankAccountApplicationService.update(bankAccountDto,AcccountId);
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

        [HttpDelete("{AcccountId}")]
        public ResponseDto Delete(long AcccountId)
        {
            try
            {
                _bankAccountApplicationService.lockAccount(AcccountId);
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
