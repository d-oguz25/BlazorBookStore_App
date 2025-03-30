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
    public class UserSettingsRepository : Repository<UserPersonalProfile>, IUserSettingsRepository
    {
        private readonly BookStore_DbContext _db;
        public UserSettingsRepository(BookStore_DbContext db) : base(db)
        {
            _db = db;
        }
    }
}
