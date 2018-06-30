
namespace Transactions.application
{
    using BankAccount.Domain.Entity;
    using AutoMapper;
    using Common.Application;
    using Common.Application.Enumeration;
    using Common.Infrastructure.Repository;
    using System;
    using Transactions.Application.Dto;
    using Transactions.Domain.Service;
    using Transactions.Application;


    public class TransactionApplicationService : ITransactionApplicationService
    {
        private readonly TransferDomainService transferDomainService;
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IMapper _mapper;

        public TransactionApplicationService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            transferDomainService = new TransferDomainService();
            _iUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        public void performCreate(RequestBankTransferDto requestBankTransferDto)
        {
            Notification notification = this.validation(requestBankTransferDto);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            BankAccount originAccount = _iUnitOfWork.BankAccounts.findByNumberLocked(requestBankTransferDto.fromAccountNumber);
            BankAccount destinationAccount = _iUnitOfWork.BankAccounts.findByNumberLocked(requestBankTransferDto.toAccountNumber);

            this.transferDomainService.performTransfer(originAccount, destinationAccount, requestBankTransferDto.amount);

            this._iUnitOfWork.BankAccounts.save(originAccount);
            this._iUnitOfWork.BankAccounts.save(destinationAccount);
            this._iUnitOfWork.Complete();
        }

        private Notification validation(RequestBankTransferDto requestBankTransferDto)
        {
            Notification notification = new Notification();
            if (requestBankTransferDto == null || requestBankTransferDto.requestBodyType == RequestBodyType.Invalid)
            {
                notification.addError("Invalid JSON data in request body.");
            }
            return notification;
        }
    }
}
