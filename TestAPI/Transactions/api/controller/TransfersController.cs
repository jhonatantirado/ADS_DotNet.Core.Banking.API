using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Api.Controller;
using Common.Application.Dto;
using Common.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Transactions.Application.Dto;
using Transactions.Application;
using BankAccount.Application.Dto;
using Common.constantes;
using Customer.Application.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Transactions.Api
{
    [Authorize]
    [Route("api/[controller]")]
    public class TransfersController : Controller
    {
        ITransactionApplicationService _transactionApplicationService;
        ResponseHandler responseHandler;
       
        public TransfersController(ITransactionApplicationService transactionApplicationService )
        {
            _transactionApplicationService = transactionApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpPost]     
        public IActionResult Post([FromBody] RequestBankTransferDto requestBankTransferDto)
        {
            try
            {
                _transactionApplicationService.performCreate(requestBankTransferDto);
                return  Ok(this.responseHandler.getOkCommandResponse("Transfer done!" ,Constantes.HttpStatus.Success));
            }
            catch (ArgumentException ex)
            {
                return BadRequest( this.responseHandler.getAppCustomErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(Constantes.HttpStatus.ErrorServer, this.responseHandler.getAppExceptionResponse());
            }
        }

        [HttpGet("{CustomerId}")]
        public IActionResult Customer(long CustomerId)
        {
            try
            {
                return Ok(_transactionApplicationService.getTransferByCustomer(CustomerId));                
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
