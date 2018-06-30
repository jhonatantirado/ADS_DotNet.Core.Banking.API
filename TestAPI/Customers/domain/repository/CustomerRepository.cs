
namespace Customer.Domain.Repository
{
    using Common.Infrastructure.Repository;
    using Customer.Domain.Entity;
    using Customer.Domain.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class CustomerRepository : BaseRepository<Customer> ,  ICustomerRepository
    {
        public CustomerRepository( BankingContext context): base( context)
        {
        }


    }
}
