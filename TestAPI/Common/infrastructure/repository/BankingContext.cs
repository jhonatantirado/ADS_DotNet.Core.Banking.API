

namespace Common.Infrastructure.Repository
{
    using Customer.Domain.Entity;
    using BankAccount.Domain.Entity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BankingContext : DbContext
    {
        public BankingContext()
        {
        }

        public BankingContext(DbContextOptions<BankingContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>()
                .Property(b => b.IsActive).HasDefaultValue(true);

            modelBuilder.Entity<Customer>()
                      .HasMany(c => c.BankAccounts)
                      .WithOne(e => e.Customer);
        }

    }
}
