using Common.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Transactions.domain.entity;

namespace Transactions.domain.repository
{
    public class TransactionRepository : BaseRepository<TransDetalle>, ITransactionRepository
    {
        public TransactionRepository(BankingContext context) : base(context)
        {
        }

        public List<TransDetalle> getTransferByCustomer(long CustomerId) {
            return base.Context.Set<TransDetalle>().Where(x => x.customer_id == CustomerId).ToList();
        }
    }

            
}
