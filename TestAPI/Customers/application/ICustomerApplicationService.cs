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
    using System.Collections.Generic;
    using Common.Application.Dto;

    public interface ICustomerApplicationService 
    {
        //int create2(CustomerDto customerDto);
        long create(CustomerDto customerDto);
        GridDto getAll(int offset, int limit, string orderBy, string orderDirection);
        CustomerDto getById(long CustomerId);
        void update(CustomerDto customerDto , long CustomerId);
        void deleted(long CustomerId);
        CustomerDto findByDocumentNumber(string documentNumber);
    }
}

