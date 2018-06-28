

namespace Transactions.infraestructure
{
    using Common.infrastructure.repository;
    using Accounts.domain.repository;
    using BankAccount.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class BankAccountRepository : BaseRepository<BankAccount>  , IBankAccountRepository
    {
        public new readonly BankingContext Context;
        public BankAccountRepository(BankingContext dbContext ) : base(dbContext)
        {
            Context = dbContext;
        }

        public BankAccount findByNumber(string accountNumber)
        {
            //return Context.Set<BankAccount>().Find(accountNumber);
            return Context.Set<BankAccount>().Where(x => x.Number == accountNumber).FirstOrDefault();
        }

        public BankAccount findByNumberLocked(string accountNumber)
        {
            //Context.Customers.incl
            //return Context.Set<BankAccount>().Include("Customer").Where(x => x.Number == accountNumber).FirstOrDefault();
            return Context.Set<BankAccount>().Where(x => x.Number == accountNumber).FirstOrDefault();
        }

        public void save(BankAccount bankAccount)
        {
            Context.BankAccounts.Update(bankAccount);
            Context.SaveChanges();
            //Context.Set<BankAccount>().Attach(bankAccount);
            //Context.Entry<BankAccount>().State = EntityState.Modified;

        }
    }
}
