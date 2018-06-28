

namespace Accounts.domain.repository
{
    using BankAccount.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common.infrastructure.repository;

    public interface IBankAccountRepository: IBaseRepository<BankAccount>
    {
        BankAccount findByNumber(string accountNumber);
        BankAccount findByNumberLocked(string accountNumber);
        void save(BankAccount bankAccount);
    }
}
