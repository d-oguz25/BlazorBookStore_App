using COMMON.Interfaces;
using DAL.BookStoreContext;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.CircuitBreaker;
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
        private readonly AsyncCircuitBreakerPolicy _circuitBreakerPolicy;
        internal DbSet<T> dbSet;
        public Repository(BookStore_DbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
            _circuitBreakerPolicy = Policy.Handle<Exception>().CircuitBreakerAsync(2, TimeSpan.FromSeconds(10),
                onBreak: (ex, duration) => Console.WriteLine("ON BREAK with ex and in duration"),
                onReset: () => Console.WriteLine("Circuit reset"),
                onHalfOpen: () => Console.WriteLine("Circuit Half Open")
                );
        }

        public async Task<T> GetById(int id)
        {
            return await _circuitBreakerPolicy.ExecuteAsync(async () =>
            {
               return await dbSet.FindAsync(id);
            });
        }
        public void Add(T entity)
        {

            dbSet.Add(entity);
        }

        public void Delete(T Entity)
        {
            _db.Remove<T>(Entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null)
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

            return query.ToList();
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
