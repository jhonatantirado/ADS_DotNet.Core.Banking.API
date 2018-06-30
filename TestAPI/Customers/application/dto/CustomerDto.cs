namespace Customer.Application.Dto
{
using Common.Application.Dto;
using Common.Application.Enumeration;
using System.Collections.Generic;
using Account.Application.Dto;

public class CustomerDto: RequestBaseDto {

        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }

        private List<BankAccountDto> BankAccounts;

}

}

