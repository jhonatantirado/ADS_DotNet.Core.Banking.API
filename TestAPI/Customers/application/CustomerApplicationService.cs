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


    public class CustomerApplicationService : ICustomerApplicationService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IMapper _mapper;

        public CustomerApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _iUnitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public void create(CustomerDto customerDto)
        {
            Notification notification = this.validation(customerDto);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            Customer customer = _mapper.Map<Customer>(customerDto);
            customer.IsActive = true;
            _iUnitOfWork.Customers.Add(customer);
            _iUnitOfWork.Complete();
        }

        public void deleted(int Id)
        {
            _iUnitOfWork.Customers.delete(Id);
            _iUnitOfWork.Complete();
        }

        public void update(CustomerDto customerDto)
        {
            Notification notification = this.validation(customerDto);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }

            Customer customer = _mapper.Map<Customer>(customerDto);
            _iUnitOfWork.Customers.Update(customer);
            _iUnitOfWork.Complete();
        }

        private Notification validation(CustomerDto customerDto)
        {
            Notification notification = new Notification();
            if (customerDto == null || customerDto.requestBodyType == RequestBodyType.Invalid)
            {
                notification.addError("Invalid JSON data in request body.");
            }

            if (string.IsNullOrWhiteSpace(customerDto.FirstName))
            {

                notification.addError("First Name is required.");
            }

            if (string.IsNullOrWhiteSpace(customerDto.LastName))
            {
                notification.addError("Last Name is required.");
            }

            if (string.IsNullOrWhiteSpace(customerDto.DocumentNumber))
            {
                notification.addError("Document Number is required.");
            }

            return notification;
        }
    }
}

