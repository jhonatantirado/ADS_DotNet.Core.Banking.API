
namespace BankAccount.Api
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using BankAccount.Application.Dto;
    using Common.Application.Dto;
    using Common.Api.Controller;
    using BankAccount.Application;

    [Route("api/Accounts")]
    public class BankAccountController : Controller
    {
        IBankAccountApplicationService _bankAccountApplicationService;
        ResponseHandler responseHandler;

        public BankAccountController(IBankAccountApplicationService bankAccountApplicationService)
        {
            _bankAccountApplicationService = bankAccountApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpGet("bankAccount/{AccountId}")]
        public IActionResult Get(long AccountId)
        {
            try
            {
                return Created(nameof(Get), _bankAccountApplicationService.getById(AccountId));
            }
            catch (Exception)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }

        }

        [HttpGet("bankAccount")]
        public IActionResult Get(int offset, int limit)
        {
            try
            {
                return Created(nameof(Get), _bankAccountApplicationService.getAll(offset, limit));
            }
            catch (Exception)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }

        }

        [HttpGet("getAccountIdCustomer/{CustomerId}")]
        public IActionResult getAccountIdCustomer(long CustomerId)
        {
            try
            {
                return Created(nameof(Get), _bankAccountApplicationService.getByIdCustomer(CustomerId));
            }
            catch (Exception)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpPost("bankAccount")]
        public IActionResult Post([FromBody] BankAccountDto bankAccountDto)
        {
            try
            {
                _bankAccountApplicationService.create(bankAccountDto);
                return Created(nameof(Post), this.responseHandler.getOkCommandResponse("Bank Account created!"));
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

        [HttpPut("bankAccount/{AcccountId}")]
        public IActionResult Put([FromBody] BankAccountDto bankAccountDto, long AcccountId)
        {
            try
            {
                _bankAccountApplicationService.update(bankAccountDto, AcccountId);
                return Created(nameof(Put), this.responseHandler.getOkCommandResponse("Bank Account updated!"));
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

        [HttpDelete("bankAccount/{AcccountId}")]
        public IActionResult Delete(long AcccountId)
        {
            try
            {
                _bankAccountApplicationService.lockAccount(AcccountId);
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
