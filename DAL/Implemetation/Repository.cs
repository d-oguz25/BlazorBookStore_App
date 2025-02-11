using COMMON.Interfaces;
using DAL.BookStoreContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implemetation
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly BookStore_DbContext _db;
        internal DbSet<T> dbSet;
        public Repository(BookStore_DbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }
        public void Add(T entity)
        {

            dbSet.Add(entity);
        }

        public void Delete(T Entity)
        {
            _db.Remove<T>(Entity);
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, Func<IOrderedQueryable>>? orderBy = null, string? includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public void Update(T Entity)
        {
            _db.Update(Entity);
        }
        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
