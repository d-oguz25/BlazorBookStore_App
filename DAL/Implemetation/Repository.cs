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

        public async Task<T> GetById(int id)
        {  
            return await dbSet.FindAsync(id);
        }
        public void Add(T entity)
        {

            dbSet.Add(entity);
        }

        public void Delete(T Entity)
        {
            _db.Remove<T>(Entity);
        }

        public IQueryable<T> GetAll(
           Expression<Func<T, bool>>? filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
           string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }



        public void Update(T Entity)
        {
            _db.Update(Entity);
        }
        public async Task SaveChanges()
        {
            _db.SaveChangesAsync();
        }
    }
}
