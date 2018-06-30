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

namespace Transactions.Api
{
    [Route("api/[controller]")]
    public class TransfersController 
    {
        ITransactionApplicationService _transactionApplicationService;
        ResponseHandler responseHandler;
       
        public TransfersController(ITransactionApplicationService transactionApplicationService )
        {
            _transactionApplicationService = transactionApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpPost]     
        public ResponseDto Post([FromBody] RequestBankTransferDto requestBankTransferDto)
        {
            try
            {
                _transactionApplicationService.performCreate(requestBankTransferDto);
                return this.responseHandler.getOkCommandResponse("Transfer done!");
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
