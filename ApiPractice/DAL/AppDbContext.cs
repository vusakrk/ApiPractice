using ApiPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPractice.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BookAuthor>()
                .HasKey(b => new { b.BookId, b.AuthorId });

            builder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(b => b.BookAuthor)
                .HasForeignKey(b => b.BookId);

            builder.Entity<BookAuthor>()
                .HasOne(b => b.Author)
                .WithMany(b => b.BookAuthor)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
