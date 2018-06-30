

namespace Transactions.Infraestructure
{
    using Common.Infrastructure.Repository;
    using BankAccount.Domain.Repository;
    using BankAccount.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class BankAccountRepository : BaseRepository<BankAccount>  , IBankAccountRepository
    {
        public BankAccountRepository(BankingContext dbContext ) : base(dbContext)
        {
        }

        public BankAccount findByNumber(string accountNumber)
        {
            return base.Context.Set<BankAccount>().Where(x => x.Number == accountNumber).FirstOrDefault();
        }

        public BankAccount findByNumberLocked(string accountNumber)
        {   
            return base.Context.Set<BankAccount>().Where(x => x.Number == accountNumber).FirstOrDefault();
        }

        public void lockAccount(int Id)
        {
            var bankAccount = base.GetById(Id);
            bankAccount.IsLocked = true;
            base.Update(bankAccount);
        }

        public void save(BankAccount bankAccount)
        {
            base.Update(bankAccount);
        }
    }
}
