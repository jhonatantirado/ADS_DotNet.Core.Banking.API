
namespace Account.Application
{
    using Account.Application.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IAccountApplicationService
    {
        void create(BankAccountDto bankAccountDto);
        void update(BankAccountDto bankAccountDto);
        void lockAccount(int Id);
    }
}
