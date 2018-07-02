using Common.infrastructure.repository;
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
            //Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            //return Context.Set<T>().ToList();
            return _dbSet.ToList();
        }

        //public IQueryable<T> GetQueryable(long id)
        //{
        //    //return _dbSet.Find(id);
        //    return _dbSet.Where(x => x.Id == id).AsQueryable();
        //}

        public T GetById(long id)
        {
            //return _dbSet.Find(id);
            return Context.Set<T>().Find(id);
            //return _dbSet.Where(x => x.Id == id).AsQueryable();
        }

        public void Remove(long Id)
        {
            _dbSet.Remove(GetById(Id));
            //context.SaveChanges();

            //if ( Context.Entry(entity ).State== EntityState.Deleted)
            //{
            //    _dbSet.Attach(entity);
            //    _dbSet.Remove(entity);
            //}
        }

        public void Update(T entity)
        {

            _dbSet.Update(entity);
            //Context.Set<T>().Update(entity);
            //_dbSet.Attach(entity);
            //var entry = _dbSet.Entry(entity);
            //Context.Entry(entity).State =EntityState.Modified;Context.Entry(entity).State =EntityState.Modified;
            //_dbSet<T>.stat  db.Entry(dboriginalmodificada).State = System.Data.EntityState.Modified;
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
