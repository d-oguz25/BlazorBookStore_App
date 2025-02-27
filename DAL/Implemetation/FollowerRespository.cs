using BlazorBookStore_App.Components.Models;
using COMMON.Interfaces;
using DAL.BookStoreContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implemetation
{
    public class FollowerRepository : Repository<Followers>, IFollowerRepository
    {
        private readonly BookStore_DbContext _dbContext;
        public FollowerRepository(BookStore_DbContext db) : base(db)
        {
            _dbContext = db;
        }
    }
}
