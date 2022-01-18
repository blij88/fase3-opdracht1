using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace PhoneShop.Business.Interfaces
{

    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetQueryIncludes(Expression<Func<T, object>> include);
        IEnumerable<T> SearchQuery(Expression<Func<T, bool>> expression);
        void Create (T entity);
        void createMultiple(IEnumerable<T> entities);
        void Update (T entity);
        void Delete (int id);
        
        
    }
}
