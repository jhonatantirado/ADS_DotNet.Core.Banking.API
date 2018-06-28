namespace Customer.Domain.Repository
{
    using Customer.Domain.Entity;
    using Common.infrastructure.repository;

    public interface ICustomerRepository: IBaseRepository<Customer>
    {
    }

}

