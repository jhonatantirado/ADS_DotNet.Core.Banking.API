

namespace Automapper
{
    using Customer.Domain.Entity;
    using Customer.Application.Dto;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Account.Application.Dto;
    using BankAccount.Domain.Entity;
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
        }
    }
}

