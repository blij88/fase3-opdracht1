using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace PhoneShop.Business.Interfaces
{

    public interface IRepository<T> where T : class
    {
        T Get(int id);
        T Get(string name);
        IEnumerable<T> Get();
        IEnumerable<T> SearchQuery(string query, Expression<Func<T, bool>> expression);
        void Create (T entity);
        void createMultiple(IEnumerable<T> entities);
        void Update (T entity);
        void Delete (int id);
        
        
    }
}
