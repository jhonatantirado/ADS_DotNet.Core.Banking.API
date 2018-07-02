
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

        public void delete(long CustomerId)
        {
            var customer = base.GetById(CustomerId);
            customer.IsActive = false;
            base.Update(customer);
        }

        public Customer findByOtherDocumentNumber(string documentNumber, long IdCustomer)
        {
            return base.Context.Set<Customer>().Where(x => x.DocumentNumber == documentNumber && x.Id != IdCustomer).FirstOrDefault();
        }

        public Customer findByOtherUserName(string user, long IdCustomer)
        {
            return base.Context.Set<Customer>().Where(x => x.User== user && x.Id != IdCustomer).FirstOrDefault();
        }
    }
}
