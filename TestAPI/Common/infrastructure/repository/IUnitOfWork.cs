
namespace Common.Infrastructure.Repository
{
    using Account.Domain.Repository;
    using Customer.Domain.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get; }
        IBankAccountRepository BankAccounts { get; }
        int Complete();
    }
}
