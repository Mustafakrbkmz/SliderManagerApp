using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SliderManagerApp.Repository.Abstract
{
    public interface IGenericRepository<T> where T :class
    {

        T Get(int id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T,bool>> predicate);
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();

    }
}
