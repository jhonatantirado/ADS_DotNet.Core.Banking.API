
namespace Customer.Domain.Repository
{
    using Common.Infrastructure.Repository;
    using Customer.Domain.Entity;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BankingContext context) : base(context)
        {
        }

        public void delete(long CustomerId)
        {
            var customer = base.GetById(CustomerId);
            customer.IsActive = false;
            base.Update(customer);
        }

        public Customer findByDocumentNumber(string documentNumber)
        {
            return base.Context.Set<Customer>().Where(x => x.DocumentNumber == documentNumber && x.IsActive).FirstOrDefault();
        }

        public Customer findByOtherDocumentNumber(string documentNumber, long IdCustomer)
        {
            return base.Context.Set<Customer>().Where(x => x.DocumentNumber == documentNumber && x.Id != IdCustomer).FirstOrDefault();
        }

        public Customer findByOtherUserName(string user, long IdCustomer)
        {
            return base.Context.Set<Customer>().Where(x => x.User == user && x.Id != IdCustomer).FirstOrDefault();
        }

        public Customer login(Customer customer)
        {
            return base.Context.Set<Customer>().Where(x => x.User == customer.User && x.Password == customer.Password).FirstOrDefault();
        }
    }
}
