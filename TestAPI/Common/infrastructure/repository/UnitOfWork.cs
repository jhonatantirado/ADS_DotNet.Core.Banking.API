

namespace Common.infrastructure.repository
{
    using Customer.Domain.Repository;
    using Common.Infrastructure.Repository;
    using BankAccount.Domain.Repository;
    using Transactions.domain.repository;

    public class UnitOfWork  : IUnitOfWork
    {
        protected readonly BankingContext _context;

        public UnitOfWork(BankingContext dbContext)
        {
            _context = dbContext;
            Customers = new CustomerRepository(_context);
            BankAccounts = new BankAccountRepository(_context);
            Transactions = new TransactionRepository(_context);
        }

        public ICustomerRepository Customers { get; private set; }
        public IBankAccountRepository BankAccounts { get; private set; }
        public ITransactionRepository Transactions { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}
