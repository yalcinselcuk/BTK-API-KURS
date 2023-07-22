using Microsoft.EntityFrameworkCore;
using StoreApp.API.Data.Config;
using StoreApp.API.Models;

namespace StoreApp.API.Repositories
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfig());
        }
    }
}
