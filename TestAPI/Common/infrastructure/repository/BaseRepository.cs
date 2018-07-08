
namespace Common.Infrastructure.Repository
{
    using Common.infrastructure.repository;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        DbSet<T> _dbSet;
      
        protected readonly BankingContext Context;

        public BaseRepository(BankingContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return _dbSet
                   .Where(predicate)
                   .AsEnumerable();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }


        public T GetById(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Remove(long Id)
        {
            _dbSet.Remove(GetById(Id));
       
        }

        public void Update(T entity)
        {

            _dbSet.Update(entity);
        }

        public IEnumerable<T> GetAllWithPaginated(int pageNumber, int pageSize, string orderBy, string orderDirection)
        {
            var skip = (pageNumber - 1) * pageSize;
            return Context.Set<T>()
                .OrderBy(orderBy, orderDirection)
                .Skip(skip)
                .Take(pageSize);
        }


        public int CountTotalRecords()
        {
            return Context.Set<T>().Count();
        }
    }
}
