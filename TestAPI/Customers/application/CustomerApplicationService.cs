namespace Customer.Application
{

    using Customer.Domain.Repository;
    using Customer.Domain.Entity;
    using Common.Application;
    using Customer.Application.Dto;
    using Common.Application.Enumeration;
    using System;
    using Common.infrastructure.repository;
    using AutoMapper;

    public class CustomerApplicationService
    {
        private readonly IMapper _mapper;
        private readonly BankingContext _dbContext;

        public CustomerApplicationService(BankingContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        //private ICustomerRepository customerRepository;

        public void performCreate(CustomerDto customerDto)
        {
            Notification notification = this.validation(customerDto);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }                        

            Customer customer = _mapper.Map<Customer>(customerDto);
            customer.IsActive = true;

            UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            //unitOfWork.Customers.Add(customer);
            unitOfWork.getRepoInstance<Customer>().Add( customer );
            unitOfWork.Complete();

        }

        private Notification validation(CustomerDto customerDto)
        {
            Notification notification = new Notification();
            if (customerDto == null || customerDto.getRequestBodyType() == RequestBodyType.Invalid)
            {
                notification.addError("Invalid JSON data in request body.");
            }
            return notification;
        }
    }
}

