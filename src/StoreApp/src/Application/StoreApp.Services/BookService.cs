using StoreApp.Entities;
using StoreApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IList<Book> GetAll()
        {
            return bookRepository.GetAll();
        }

        public Book? GetById(int id)
        {
            return (bookRepository.GetById(id));
        }

        public void Create(Book entity)
        {
            bookRepository.Create(entity);
        }

        public void Delete(Book entity)
        {
            bookRepository.Delete(entity);
        }

        public void Update(int id, Book entity)
        {
            bookRepository.Update(id, entity);
        }

    }
}
