
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

            int n = 100;
            for (int i =1; i < n; i++)
            {
                var newCustomer = new Customer { FirstName = "Name" + i, LastName = "Ape"+ i, DocumentNumber = i.ToString().PadLeft(9,'0'), IsActive = true, Password = "abc"+i, id_rol = 1, User = "user"+ i };
                _context.Customers.Add(newCustomer);
                _context.BankAccounts.Add(new BankAccount {  CustomerId = newCustomer.Id, Customer = newCustomer, Balance = 100, IsLocked = false, Number = i.ToString().PadLeft(9, '0') });
            }


            //_context.BankAccounts.Add(new BankAccount { Customer = newCustomer, Balance = 1500, IsLocked = false, Number = "123-456-001" });
            //_context.BankAccounts.Add(new BankAccount { Customer = newCustomer, Balance = 1800, IsLocked = false, Number = "123-456-002" });

            _context.Roles.Add(new Role { Id = 1, IsActive = true, Role_Name = "Cliente" });

            _context.SaveChanges();

        }
    }
}
