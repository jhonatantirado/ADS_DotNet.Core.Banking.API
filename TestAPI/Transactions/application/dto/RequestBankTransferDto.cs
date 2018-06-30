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

        //public string getFromAccountNumber()
        //{
        //    return fromAccountNumber;
        //}

        //public void setFromAccountNumber(string fromAccountNumber)
        //{
        //    this.fromAccountNumber = fromAccountNumber;
        //}

        //public string getToAccountNumber()
        //{
        //    return toAccountNumber;
        //}

        //public void setToAccountNumber(string toAccountNumber)
        //{
        //    this.toAccountNumber = toAccountNumber;
        //}

        //public decimal getAmount()
        //{
        //    return amount;
        //}

        //public void setAmount(decimal amount)
        //{
        //    this.amount = amount;
        //}

    }
}
