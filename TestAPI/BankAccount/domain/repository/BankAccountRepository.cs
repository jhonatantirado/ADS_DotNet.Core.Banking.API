

namespace BankAccount.Domain.Repository
{
    using Common.Infrastructure.Repository;
    using BankAccount.Domain.Repository;
    using BankAccount.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class BankAccountRepository : BaseRepository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(BankingContext dbContext) : base(dbContext)
        {
        }

        public BankAccount findByNumber(string accountNumber)
        {
            return base.Context.Set<BankAccount>().Where(x => x.Number == accountNumber).FirstOrDefault();
        }

        public BankAccount findByAccountNumber(string accountNumber)
        {
            return base.Context.Set<BankAccount>().Where(x => x.Number == accountNumber && !x.IsLocked).FirstOrDefault();
        }


        public BankAccount findByNumberLocked(string accountNumber)
        {
            return base.Context.Set<BankAccount>().Where(x => x.Number == accountNumber).FirstOrDefault();
        }

        public BankAccount findByOtherNumber(string accountNumber, long IdBankAccount)
        {
            return base.Context.Set<BankAccount>().Where(x => x.Number == accountNumber && x.Id != IdBankAccount).FirstOrDefault();
        }

        public List<BankAccount> getBankAccountsByIdCustomer(long CustomerId)
        {
            return base.Context.Set<BankAccount>().Where(x => x.CustomerId == CustomerId &&  !x.IsLocked  ).ToList();
        }

        public void lockAccount(long Id)
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
