

namespace Common.infrastructure.repository
{
    using Customer.Domain.Repository;
    using Common.infrastructure.repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;
    using Accounts.domain.repository;

    public class UnitOfWork // : IUnitOfWork
    {
        protected readonly BankingContext Context;
        
        public UnitOfWork(BankingContext dbContext)
        {
            Context = dbContext;
            //Customers = new CustomerRepository(_context);
            //BankAccounts = new BankAccountRepository(_context);
        }

        //public ICustomerRepository Customers { get; private set; }
        //public IBankAccountRepository BankAccounts { get; private set; }

        public BaseRepository<T> getRepoInstance<T>() where T : class
        {
            return new BaseRepository<T>(Context);
        }

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }


    }
}
