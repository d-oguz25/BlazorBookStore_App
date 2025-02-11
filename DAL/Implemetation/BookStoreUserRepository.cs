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
    public class BookStoreUserRepository : Repository<User>, IBookStoreUserRepository
{
        private readonly BookStore_DbContext _db;

        public BookStoreUserRepository(BookStore_DbContext db) : base(db)
        {
            _db = db;
        }
    }
}