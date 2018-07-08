
namespace Common.Infrastructure.Repository
{
    using BankAccount.Domain.Repository;
    using Customer.Domain.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Transactions.domain.repository;

    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IBankAccountRepository BankAccounts { get; }
        ITransactionRepository Transactions  { get; }
        int Complete();
    }
}
