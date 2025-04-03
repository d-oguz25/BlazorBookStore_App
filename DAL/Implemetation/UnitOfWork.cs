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
            following_list=new FollowerRepository(_db);
            logged_user = new LoggedUserRepository(_db);
            userSettings = new UserSettingsRepository(_db);


        }
        public IBookRepository books { get; set; }

        public ICommentRepository comments { get; set; }

        public IBookStoreUserRepository users { get; set; }

        public IFollowerRepository following_list { get; set; }

        public ILoggedUserRepository logged_user { get; set; }

        public IUserSettingsRepository userSettings { get; set; }
    }
}
