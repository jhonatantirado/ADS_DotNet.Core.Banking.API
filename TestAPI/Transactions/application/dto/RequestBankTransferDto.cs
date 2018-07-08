namespace Transactions.Application.Dto
{
    using Common.Application.Dto;
    using Common.Application.Enumeration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RequestBankTransferDto: RequestBaseDto
    {
        
        public string fromAccountNumber { get; set; }
        public string toAccountNumber { get; set; }
        public decimal amount { get; set; }

        public RequestBankTransferDto(string fromAccountNumber, string toAccountNumber, decimal amount, RequestBodyType requestBodyType)
        {
            this.fromAccountNumber = fromAccountNumber;
            this.toAccountNumber = toAccountNumber;
            this.amount = amount;
            this.requestBodyType = requestBodyType;
        }

     
    }
}
