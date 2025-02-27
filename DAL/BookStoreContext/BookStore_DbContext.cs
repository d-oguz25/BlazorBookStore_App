using BlazorBookStore_App.Components.Models;
using COMMON.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BookStoreContext
{
    public class BookStore_DbContext:DbContext
    {
        public DbSet<Book> Books {  get; set; }
        public DbSet<Comment> Comments {  get; set; }
        public DbSet<Genre> Genres {  get; set; }
        public DbSet<User> Users {  get; set; }
        public DbSet<LoggedUser> LoggedUsers {  get; set; }
        public DbSet<UserPersonalProfile> User_Profile_Details {  get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BlazorDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasMany(x=> x.Comments).WithOne(x=> x.Book).HasForeignKey(x=>x.BookId);
                entity.Property(x => x.Name).HasColumnName("Name").HasDefaultValue("Unknown");
                entity.HasOne(b => b.Genre).WithMany(x => x.Books).HasForeignKey(x => x.GenreId).OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(h => h.Id);
                entity.HasOne(x => x.Session_Details).WithOne(x => x.User).HasForeignKey<LoggedUser>(l => l.UserId);
               
            });
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserId);
            });
        }

    }
}
