using System;
using System.Collections.Generic;
using System.Text;
using LeafLit.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeafLit.Data
{
    public class BookDbContext : DbContext
    {
        //public DbSet<Shelf> Shelves { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<User> Users { get; set; }


        public DbSet<UserBook> UserBooks { get; set; }

        public DbSet<UserBookRating> UserBookRatings { get; set; }
        
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserBook>()
                .HasKey(b => new { b.UserID, b.BookID });

            modelBuilder.Entity<UserBookRating>()
                .HasKey(b => new { b.UserID, b.BookID });

            base.OnModelCreating(modelBuilder);
        }


    }
}
