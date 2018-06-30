namespace BankAccount.Application
{

    using AutoMapper;
    using Common.Infrastructure.Repository;
    using System;
    using BankAccount.Domain.Entity;
    using Common.Application;
    using BankAccount.Application.Dto;

    public class BankAccountApplicationService : IBankAccountApplicationService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IMapper _mapper;

        public BankAccountApplicationService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            _iUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        public void create(BankAccountDto bankAccountDto)
        {
            BankAccount bankAccount = _mapper.Map<BankAccount>(bankAccountDto);
            Notification notification = bankAccount.validateSaveBankAccount();
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            _iUnitOfWork.BankAccounts.Add(bankAccount);
            _iUnitOfWork.Complete();
        }

        public void update(BankAccountDto bankAccountDto)
        {
            Notification notification = this.validation(bankAccountDto);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }

            BankAccount bankAccount = _mapper.Map<BankAccount>(bankAccountDto);
            notification = bankAccount.validateSaveBankAccount();
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            _iUnitOfWork.BankAccounts.Update(bankAccount);
            _iUnitOfWork.Complete();
        }

        public void lockAccount(int Id)
        {
            _iUnitOfWork.BankAccounts.lockAccount(Id);
            _iUnitOfWork.Complete();
        }


        private Notification validation(BankAccountDto bankAccountDto)
        {
            Notification notification = new Notification();
            if (bankAccountDto == null)
            {
                notification.addError("Invalid JSON data in request body.");
            }
            return notification;
        }

    }
}
