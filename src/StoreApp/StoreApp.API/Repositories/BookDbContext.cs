using Microsoft.EntityFrameworkCore;
using StoreApp.API.Models;

namespace StoreApp.API.Repositories
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
    }
}
