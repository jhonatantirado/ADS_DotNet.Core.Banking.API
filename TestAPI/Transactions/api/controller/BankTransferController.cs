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
using Account.Application.Dto;

namespace Transactions.Api
{
    [Route("api/[controller]")]
    public class BankTransferController 
    {
        ITransactionApplicationService _transactionApplicationService;
        ResponseHandler responseHandler;
       
        public BankTransferController(ITransactionApplicationService transactionApplicationService )
        {
            _transactionApplicationService = transactionApplicationService;
            responseHandler = new ResponseHandler();
        }

        [HttpPost]
        [Route("transfers")]
        public ResponseDto performCreate([FromBody] RequestBankTransferDto requestBankTransferDto)
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

        //[HttpPost]
        //public ResponseDto Post([FromBody] BankAccountDto bankAccountDto)
        //{
        //    try
        //    {
        //        _transactionApplicationService.create(bankAccountDto);
        //        return this.responseHandler.getOkCommandResponse("Bank Account created!");
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return this.responseHandler.getAppCustomErrorResponse(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.responseHandler.getAppExceptionResponse();
        //    }
        //}


        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        //// PUT api/<controller>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
