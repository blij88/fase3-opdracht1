using Microsoft.Extensions.Configuration;
using PhoneShop.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace PhoneShop.Business.Repositories
{

    public class AdoRepository<T> : IRepository<T> where T : class
    {
        public void Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void createMultiple(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Get()
        {
            throw new NotImplementedException();
        }

        public T Get(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SearchQuery(string query, Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
