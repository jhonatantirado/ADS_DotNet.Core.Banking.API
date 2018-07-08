
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
    using Customer.Application.Dto;
    using System.Collections.Generic;
    using Transactions.application.dto;
    using Transactions.domain.entity;

    public class TransactionApplicationService : ITransactionApplicationService
    {
        private readonly TransactionDomainService transferDomainService;
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IMapper _mapper;

        public TransactionApplicationService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            transferDomainService = new TransactionDomainService();
            _iUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        public List<TransDetalleDto> getTransferByCustomer(long CustomerId)
        {
           var TransferDetalleResult =  _iUnitOfWork.Transactions.getTransferByCustomer(CustomerId);
            List<TransDetalleDto> TransferDetalleResponse = _mapper.Map< List<TransDetalleDto>>(TransferDetalleResult);
            return TransferDetalleResponse;
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

            var idCustomer = originAccount.CustomerId;

            this._iUnitOfWork.BankAccounts.save(originAccount);
            this._iUnitOfWork.BankAccounts.save(destinationAccount);

            TransDetalle transDetalle = new TransDetalle() { customer_id  = idCustomer
                                                                                        , numb_origen = requestBankTransferDto.fromAccountNumber
                                                                                        , numb_destino = requestBankTransferDto.toAccountNumber
                                                                                        , fecha = DateTime.Now
                                                                                        , monto = requestBankTransferDto.amount
                                                                                         };
            this._iUnitOfWork.Transactions.Add(transDetalle);

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
