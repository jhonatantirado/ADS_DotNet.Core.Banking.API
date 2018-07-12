namespace Customer.Application.Dto
{
using Common.Application.Dto;
using Common.Application.Enumeration;
using System.Collections.Generic;
using BankAccount.Application.Dto;
    using System;

    public class CustomerDto: RequestBaseDto {

        public string Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; }
        public int id_rol { get; set; }
        public string User { get; set; }
        public List<BankAccountDto> BankAccounts { get; set; }

}

}

