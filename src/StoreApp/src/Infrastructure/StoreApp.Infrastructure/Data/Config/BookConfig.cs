using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Entities;
namespace StoreApp.Infrastructure.Data.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book() { Id = 1, Title = "Suç ve Ceza", Price = 100 },
                new Book() { Id = 2, Title = "Sefiller", Price = 90 },
                new Book() { Id = 3, Title = "Anna Karenina", Price = 110 }
            );
        }
    }
}
