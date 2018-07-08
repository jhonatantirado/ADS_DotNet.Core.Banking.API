

namespace Automapper
{
    using Customer.Domain.Entity;
    using Customer.Application.Dto;
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using BankAccount.Application.Dto;
    using BankAccount.Domain.Entity;
    using Transactions.domain.entity;
    using Transactions.application.dto;

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
            CreateMap<TransDetalle, TransDetalleDto>().ReverseMap();
            CreateMap<List<Customer>, List<CustomerDto>>().ReverseMap();
         
            
        }
    }
}

