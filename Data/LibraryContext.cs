using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nohai_Dragos_Ionut_Lab2.Models;

namespace Nohai_Dragos_Ionut_Lab2.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublishedBook> PublishedBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Publisher>().ToTable("Publisher");
            modelBuilder.Entity<PublishedBook>().ToTable("PublishedBook");
            modelBuilder.Entity<PublishedBook>().HasKey(c => new { c.BookID, c.PublisherID });
        }
    }
}
