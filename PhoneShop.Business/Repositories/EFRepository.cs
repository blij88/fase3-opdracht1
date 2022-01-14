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

        public IEnumerable<T> Get()
        {
            return db.Set<T>().ToList();
        }

        public T Get(string name)
        {
            return db.Set<T>().Find(name);
        }

        public IEnumerable<T> SearchQuery(string query, Expression<Func<T, bool>> expression)
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
