
namespace BankAccount.Application
{
    using BankAccount.Application.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IBankAccountApplicationService
    {
        void create(BankAccountDto bankAccountDto);
        void update(BankAccountDto bankAccountDto);
        void lockAccount(int Id);
    }
}
