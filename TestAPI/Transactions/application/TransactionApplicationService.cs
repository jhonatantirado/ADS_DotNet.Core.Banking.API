
namespace Transactions.application
{
    using BankAccount.Domain.Entity;
    using AutoMapper;
    using Common.Application;
    using Common.Application.Enumeration;
    using Common.infrastructure.repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Transactions.application.dto;
    using Transactions.domain.service;
    using Transactions.infraestructure;

    public class TransactionApplicationService
    {
        private readonly IMapper _mapper;
        private readonly BankingContext _dbContext;
        private readonly TransferDomainService transferDomainService;
        private readonly BankAccountRepository bankAccountRepository;

        public TransactionApplicationService(BankingContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            transferDomainService = new TransferDomainService();
            bankAccountRepository =new  BankAccountRepository( dbContext );
        }

        public void performCreate(RequestBankTransferDto requestBankTransferDto)
        {
            Notification notification = this.validation(requestBankTransferDto);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }


            //UnitOfWork unitOfWork = new UnitOfWork(_dbContext);
            //unitOfWork.getRepoInstance<Customer>().Add(customer);
            //BankAccount originAccount = this.bankAccountRepository.findByNumberLocked(requestBankTransferDto.getFromAccountNumber());
            BankAccount originAccount = this.bankAccountRepository.findByNumberLocked(requestBankTransferDto.getFromAccountNumber());
            BankAccount destinationAccount = this.bankAccountRepository.findByNumberLocked(requestBankTransferDto.getToAccountNumber());

            this.transferDomainService.performTransfer(originAccount, destinationAccount, requestBankTransferDto.getAmount());
            this.bankAccountRepository.save(originAccount);
            this.bankAccountRepository.save(destinationAccount);


        }

        private Notification validation(RequestBankTransferDto requestBankTransferDto)
        {
            Notification notification = new Notification();
            if (requestBankTransferDto == null || requestBankTransferDto.getRequestBodyType() == RequestBodyType.Invalid)
            {
                notification.addError("Invalid JSON data in request body.");
            }
            return notification;
        }
    }
}
