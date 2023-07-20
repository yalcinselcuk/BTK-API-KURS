using BookDemo.Models;

namespace BookDemo.Data
{
    public static class BookDbContext
    {
        public static IList<Book> listBooks;

        static BookDbContext()
        {
            listBooks = new List<Book>()
            {
                new Book() { Id = 1, Title = "Suç ve Ceza", Price = 100},
                new Book() { Id = 2, Title = "Sefiller", Price = 90},
                new Book() { Id = 3, Title = "Romeo ve Juliet", Price = 105}
            };
        }
    }
}
