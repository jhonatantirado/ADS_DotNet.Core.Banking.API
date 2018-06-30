
namespace Common
{
    using BankAccount.Domain.Entity;
    using Customer.Domain.Entity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common.Infrastructure.Repository;

    public class DbInitializer
    {
        private readonly BankingContext _context;

        public DbInitializer(BankingContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();

            if (context.Customers.Any())
            {
                return;
            }

            var newCustomer = new Customer { FirstName = "User1", LastName = "Ape1", IsActive = true };
            _context.Customers.Add(newCustomer);
            _context.BankAccounts.Add(new BankAccount { Customer = newCustomer, Balance = 1500, IsLocked = false, Number = "123-456-001" });
            _context.BankAccounts.Add(new BankAccount { Customer = newCustomer, Balance = 1800, IsLocked = false, Number = "123-456-002" });            
            _context.SaveChanges();

        }
    }
}
