namespace BankAccount.Application
{

    using AutoMapper;
    using Common.Infrastructure.Repository;
    using System;
    using BankAccount.Domain.Entity;
    using Common.Application;
    using BankAccount.Application.Dto;
    using BankAccount.Domain.Service;
    using Common.Application.Dto;
    using System.Linq;
    using System.Collections.Generic;
    using Customer.Domain.Entity;
    using Customers.Domain.Service;

    public class BankAccountApplicationService : IBankAccountApplicationService
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IMapper _mapper;
        private readonly BankAccountDomainService bankAccountDomainService;
        private readonly CustomerDomainService customerDomainService;

        public BankAccountApplicationService(IUnitOfWork iUnitOfWork, IMapper mapper)
        {
            bankAccountDomainService = new BankAccountDomainService();
            customerDomainService = new CustomerDomainService();
            _iUnitOfWork = iUnitOfWork;
            _mapper = mapper;
        }

        #region public methods


        public void create(BankAccountDto bankAccountDto)
        {
            BankAccount bankAccount = _mapper.Map<BankAccount>(bankAccountDto);

            Notification notification = this.validationIsNull(bankAccount);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }

            notification = bankAccount.validateSaveBankAccount();
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }
            BankAccount findBankAccount = _iUnitOfWork.BankAccounts.findByNumberLocked(bankAccountDto.Number);
            this.bankAccountDomainService.validDoesntExistNumberAccount(findBankAccount);

            Customer findCustomer = _iUnitOfWork.Customers.GetById(bankAccount.CustomerId);
            this.customerDomainService.validExistCustomer(findCustomer);

            _iUnitOfWork.BankAccounts.Add(bankAccount);
            _iUnitOfWork.Complete();
        }

        public void update(BankAccountDto bankAccountDto, long AcccountId)
        {
            BankAccount bankAccount = _mapper.Map<BankAccount>(bankAccountDto);
            bankAccount.Id = AcccountId;

            validUpdate(bankAccount);

            _iUnitOfWork.BankAccounts.Update(bankAccount);
            _iUnitOfWork.Complete();
        }

        public void lockAccount(long AcccountId)
        {
            Notification notification = this.validationAccountId(AcccountId);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }

            BankAccount findBankAccount = new BankAccount(); //_iUnitOfWork.BankAccounts.GetById(Id);
            //this.bankAccountDomainService.validExistBankAccount(findBankAccount);

            _iUnitOfWork.BankAccounts.lockAccount(AcccountId);
            _iUnitOfWork.Complete();
        }


        #endregion

        private Notification validUpdate(BankAccount bankAccount)
        {
            Notification notification = this.validationAccountId(bankAccount.Id);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }

            notification = this.validationIsNull(bankAccount);
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }

            BankAccount findBankAccount = new BankAccount(); // _iUnitOfWork.BankAccounts.GetById(bankAccount.Id);            
            this.bankAccountDomainService.validExistBankAccount(findBankAccount);

            notification = bankAccount.validateSaveBankAccount();
            if (notification.hasErrors())
            {
                throw new ArgumentException(notification.errorMessage());
            }

            findBankAccount = _iUnitOfWork.BankAccounts.findByOtherNumber(bankAccount.Number, bankAccount.Id);
            this.bankAccountDomainService.validDoesntExistNumberAccount(findBankAccount);

            Customer findCustomer = _iUnitOfWork.Customers.GetById(bankAccount.CustomerId);
            this.customerDomainService.validExistCustomer(findCustomer);

            return notification;
        }

        private Notification validationIsNull(BankAccount bankAccount)
        {
            Notification notification = new Notification();
            if (bankAccount == null)
            {
                notification.addError("Invalid JSON data in request body.");
            }
            return notification;
        }

        private Notification validationAccountId(long AccountId)
        {
            Notification notification = new Notification();
            if (AccountId == 0)
            {
                notification.addError("Id Account is Required.");
            }
            return notification;
        }


        #region private methods

        public GridDto getAll(int offset, int limit, string orderBy, string orderDirection)
        {
            List<BankAccount> bankAccounts = _iUnitOfWork.BankAccounts.GetAllWithPaginated(offset, limit, orderBy , orderDirection).ToList();
            GridDto result = new GridDto
            {
                Content = bankAccounts,
                TotalRecords = _iUnitOfWork.BankAccounts.CountTotalRecords(),
                CurrentPage = offset,
                PageSize = limit
            };
            return result;
        }

        public BankAccountDto getById(long AccountId)
        {
            var bankAccount = _iUnitOfWork.BankAccounts.GetById(AccountId);
            BankAccountDto bankAccountDto = _mapper.Map<BankAccountDto>(bankAccount);
            return bankAccountDto;
        }

        public List<BankAccountDto> getByIdCustomer(long CustomerId)
        {
            var bankAccounts = _iUnitOfWork.BankAccounts.getBankAccountsByIdCustomer(CustomerId);
            List<BankAccountDto> bankAccountDtos = _mapper.Map<List<BankAccountDto>>(bankAccounts);
            return bankAccountDtos;
        }

        public BankAccountDto findByAccountNumber(string accountNumber)
        {
            var bankAccount = _iUnitOfWork.BankAccounts.findByAccountNumber(accountNumber);

            BankAccountDto bankAccountDto = _mapper.Map<BankAccountDto>(bankAccount);
            return bankAccountDto;
        }

        #endregion


    }
}
