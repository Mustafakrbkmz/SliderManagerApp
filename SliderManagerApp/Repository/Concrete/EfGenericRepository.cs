using Microsoft.EntityFrameworkCore;
using SliderManagerApp.Entity;
using SliderManagerApp.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SliderManagerApp.Repository.Concrete
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly DbContext _context;
        public EfGenericRepository(SliderContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(int id)
        {
            var entity=Get(id);
            var deleteEntity = _context.Entry(entity);
            deleteEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            var updateproduct = _context.Entry(entity);
            updateproduct.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
