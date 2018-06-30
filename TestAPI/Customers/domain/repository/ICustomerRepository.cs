namespace Customer.Domain.Repository
{
    using Customer.Domain.Entity;
    using Common.Infrastructure.Repository;

    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        //void Delete(Cus)
    }

}

