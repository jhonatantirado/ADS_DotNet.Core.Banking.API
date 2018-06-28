using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.infrastructure.repository
{
    public interface IBaseRepository<T>
    {
        
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Remove(T entity);

        void Update(T entity);

        void SaveORUpdate(T entity);

        //public void persist(T entity);
        //public void save(T entity);
        //public void update(T entity);
        //public void merge(T entity);
        //public void saveOrUpdate(T entity);
    }
}
