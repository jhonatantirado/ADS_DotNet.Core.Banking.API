
namespace Common.infrastructure.repository
{
    using Accounts.domain.repository;
        using Customer.Domain.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IBankAccountRepository BankAccounts { get; }
        int Complete();
    }
}
