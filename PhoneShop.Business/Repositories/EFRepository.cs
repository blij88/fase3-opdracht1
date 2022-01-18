using Microsoft.EntityFrameworkCore;
using PhoneShop.Business.Data;
using PhoneShop.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneShop.Business.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext db;

        public EFRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public void Create(T entity)
        {
            db.Add<T>(entity);
            db.SaveChanges();
        }

        public void createMultiple(IEnumerable<T> entities)
        {
            db.Set<T>().AddRange(entities);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Get(id);
            db.Remove<T>(entity);
            db.SaveChanges();
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public IEnumerable<T> GetQueryIncludes(Expression<Func<T, object>> include)
        {
            return db.Set<T>().Include(include).ToList();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().FirstOrDefault(expression);
        }

        public IEnumerable<T> SearchQuery(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression).ToList();
        }

        public void Update(T entity)
        {

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
