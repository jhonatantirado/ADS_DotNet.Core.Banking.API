namespace Customer.Domain.Repository
{
    using Customer.Domain.Entity;
    using Common.Infrastructure.Repository;

    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        void delete(long CustomerId);
        Customer findByOtherDocumentNumber(string documentNumber, long IdCustomer);
        Customer findByOtherUserName(string user, long IdCustomer);
        Customer login(Customer customer);
        Customer findByDocumentNumber(string documentNumber);
    }



}

