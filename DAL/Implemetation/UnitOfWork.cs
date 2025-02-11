using COMMON.Interfaces;
using DAL.BookStoreContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implemetation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookStore_DbContext _db;
        public UnitOfWork(BookStore_DbContext db)
        {
            books= new BookRepository(_db);
            comments= new CommentRepository(_db);
            users= new BookStoreUserRepository(_db);
            
        }
        public IBookRepository books { get; set; }

        public ICommentRepository comments { get; set; }

        public IBookStoreUserRepository users { get; set; }

      
    }
}
