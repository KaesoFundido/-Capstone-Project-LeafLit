using System;
using System.Collections.Generic;
using System.Text;
using LeafLit.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeafLit.Data
{
    public class BookDbContext : IdentityDbContext
    {
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<Book> Books { get; set; }
        
        public BookDbContext(DbContextOptions<BookDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookTag>()
            .HasKey(b => new{ b.BookID, b.GenreID });   
        }


    }
}
