
namespace BankAccount.Application
{
    using BankAccount.Application.Dto;
    using Common.Application.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IBankAccountApplicationService
    {
        void create(BankAccountDto bankAccountDto);
        void update(BankAccountDto bankAccountDto, long AcccountId);
        void lockAccount(long AcccountId);
        GridDto getAll(int offset, int limit, string orderBy, string orderDirection);
        BankAccountDto getById(long AcccountId);
       List<BankAccountDto> getByIdCustomer(long CustomerId);
        BankAccountDto findByAccountNumber(string accountNumber);
        

    }
}
