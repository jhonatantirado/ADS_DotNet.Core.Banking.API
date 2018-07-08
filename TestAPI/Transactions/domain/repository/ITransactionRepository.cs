
namespace Transactions.domain.repository
{
    using Common.Infrastructure.Repository;
    using System.Collections.Generic;
    using Transactions.domain.entity;

    public interface ITransactionRepository : IBaseRepository<TransDetalle>
    {
        List<TransDetalle> getTransferByCustomer(long CustomerId);
    }
}
