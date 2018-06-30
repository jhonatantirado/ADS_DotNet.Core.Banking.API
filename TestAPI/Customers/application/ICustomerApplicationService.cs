namespace Customer.Application
{

    using Customer.Domain.Repository;
    using Customer.Domain.Entity;
    using Common.Application;
    using Customer.Application.Dto;
    using Common.Application.Enumeration;
    using System;
    using Common.Infrastructure.Repository;
    using AutoMapper;

    public interface ICustomerApplicationService 
    {
        void create(CustomerDto customerDto);
        void update(CustomerDto customerDto);
        void deleted(int Id);
    }
}

