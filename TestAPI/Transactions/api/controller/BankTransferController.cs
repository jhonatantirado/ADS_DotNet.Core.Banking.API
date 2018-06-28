using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Api.Controller;
using Common.Application.Dto;
using Common.infrastructure.repository;
using Microsoft.AspNetCore.Mvc;
using Transactions.application;
using Transactions.application.dto;

namespace Transactions.api
{
    [Route("api/[controller]")]
    public class BankTransferController //: Controller
    {
        TransactionApplicationService transactionApplicationService;
        ResponseHandler responseHandler;
        private readonly IMapper _mapper;

        public BankTransferController(BankingContext dbContext, IMapper mapper)
        {
            transactionApplicationService = new TransactionApplicationService(dbContext, mapper);
            responseHandler = new ResponseHandler();
            _mapper = mapper;
        }

        [HttpPost]
        [Route("transfers")]
        public ResponseDto performCreate([FromBody] RequestBankTransferDto requestBankTransferDto)
        {
            try
            {
                transactionApplicationService.performCreate(requestBankTransferDto);
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

        //// POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
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
