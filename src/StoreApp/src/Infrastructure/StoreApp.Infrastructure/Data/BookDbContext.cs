using Microsoft.EntityFrameworkCore;
using StoreApp.Infrastructure.Data.Config;
using StoreApp.Entities;

namespace StoreApp.Infrastructure.Data
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
