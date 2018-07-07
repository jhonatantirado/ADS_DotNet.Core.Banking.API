namespace Security.application
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Common.Infrastructure.Repository;
    using Customer.Application.Dto;
    using Customers.Domain.Service;
    using Customer.Domain.Entity;


    public class SecurityApplicationService : ISecurityApplicationService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IMapper _mapper;
        private readonly CustomerDomainService customerDomainService;

        public SecurityApplicationService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {   
            customerDomainService = new CustomerDomainService();
            _iUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        public CustomerDto login(CustomerDto customerDto)
        {
            var customerParam = _mapper.Map<Customer>(customerDto);
            var customer= _iUnitOfWork.Customers.login(customerParam);
            CustomerDto customerDtoResult= _mapper.Map<CustomerDto>( customer );
            return customerDtoResult;
        }
    }
}
