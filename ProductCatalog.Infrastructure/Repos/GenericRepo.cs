using Microsoft.EntityFrameworkCore;
using ProductCatalog.Application.Interfaces.IRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProductCatalog.Infrastructure.Repos
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly DbSet<T> _entites ;
        private readonly DbContext _context;

        public GenericRepo(DbContext context)
        {
            _entites = context.Set<T>();
            _context = context;
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> expression=null)
        {
            IQueryable<T> query = _entites;
            if (expression != null)
            {
                return query.Where(expression);
            }
             return query.ToList();
        }

        public virtual T FindById(object id)
        {
            return _entites.Find(id);
        }


        public virtual void Insert(T entity)
        {
            _entites.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _entites.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if(_context.Entry(entity).State == EntityState.Detached)
            {
                _entites.Attach(entity);
            }

            _entites.Remove(entity);
        }

        public virtual void Delete(object id)
        {
            T entity = FindById(id);
            Delete(entity);
        }
    }
}
