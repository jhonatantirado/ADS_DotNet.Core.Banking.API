using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Infrastructure.Repository
{
    public interface IBaseRepository<T>
    {
        
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
