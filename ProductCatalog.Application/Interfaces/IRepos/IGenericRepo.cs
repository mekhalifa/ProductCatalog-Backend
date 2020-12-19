using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ProductCatalog.Application.Interfaces.IRepos
{
    public interface IGenericRepo<T> where T:class
    {
        
        IEnumerable<T> Get(Expression<Func<T,bool>> expression =null);
        T FindById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);



    }
}
