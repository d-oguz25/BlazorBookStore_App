using BlazorBookStore_App.Components.Models;
using COMMON.Interfaces;
using COMMON.Models;
using DAL.BookStoreContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implemetation
{
    public class LoggedUserRepository : Repository<LoggedUser>, ILoggedUserRepository
    {
        private readonly BookStore_DbContext _dbContext;
        public LoggedUserRepository(BookStore_DbContext db) : base(db)
        {
            _dbContext = db;
        }
    }
}
