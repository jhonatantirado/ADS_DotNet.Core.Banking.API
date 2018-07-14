
namespace BankAccount.Api
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using BankAccount.Application.Dto;
    using Common.Application.Dto;
    using Common.Api.Controller;
    using BankAccount.Application;
    using Common.constantes;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [Route("api/Accounts/bankAccount")]
    public class BankAccountController : Controller
    {
        IBankAccountApplicationService _bankAccountApplicationService;
        ResponseHandler responseHandler;

        public BankAccountController(IBankAccountApplicationService bankAccountApplicationService)
        {
            _bankAccountApplicationService = bankAccountApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpGet("{AccountId}")]
        public IActionResult Get(long AccountId)
        {
            try
            {
                return Ok(_bankAccountApplicationService.getById(AccountId));
            }
            catch (Exception)
            {
                return StatusCode(500, this.responseHandler.getAppExceptionResponse());
            }

        }

        [HttpGet]
        public IActionResult Get(int offset =Constantes.DefaultPagination.defaultOffset, int limit = Constantes.DefaultPagination.defaultLimit, string orderBy = Constantes.DefaultPagination.orderBy, string orderDirection = Constantes.DefaultPagination.orderDirection)
        {
            try
            {
                return Ok(_bankAccountApplicationService.getAll(offset, limit, orderBy, orderDirection));
            }
            catch (Exception)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] BankAccountDto bankAccountDto)
        {
            try
            {
                _bankAccountApplicationService.create(bankAccountDto);
                return Created(nameof(Post), this.responseHandler.getOkCommandResponse("Bank Account created!", Constantes.HttpStatus.Created));
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

        [HttpPut("{AcccountId}")]
        public IActionResult Put([FromBody] BankAccountDto bankAccountDto, long AcccountId)
        {
            try
            {
                _bankAccountApplicationService.update(bankAccountDto, AcccountId);
                return Ok(this.responseHandler.getOkCommandResponse("Bank Account updated!", Constantes.HttpStatus.Success));
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

        [HttpDelete("{AcccountId}")]
        public IActionResult Delete(long AcccountId)
        {
            try
            {
                _bankAccountApplicationService.lockAccount(AcccountId);
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

        [Route("/api/Accounts/customer/{CustomerId}")]
        [HttpGet]
        public IActionResult Customer(long CustomerId)
        {
            try
            {
                return Ok(_bankAccountApplicationService.getByIdCustomer(CustomerId));
            }
            catch (Exception)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }
             
        [Route("/api/Accounts/findByAccountNumber")]
        [HttpGet]
        public IActionResult findByAccountNumber(string accountNumber)
        {
            try
            {
                return Ok(_bankAccountApplicationService.findByAccountNumber(accountNumber));
            }
            catch (Exception)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }

    }
}
