using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Common.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        DbSet<T> _dbSet;
        /*Probar luego cambianfo a DbContext como un parametro general*/
        //protected readonly BankingContext Context;
        protected readonly BankingContext Context;

        public BaseRepository(BankingContext context)
        {
            Context =  context ;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            return  _dbSet
                   .Where(predicate)
                   .AsEnumerable();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            //Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            //return Context.Set<T>().ToList();
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
            //return Context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            if ( Context.Entry(entity ).State== EntityState.Deleted)
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
