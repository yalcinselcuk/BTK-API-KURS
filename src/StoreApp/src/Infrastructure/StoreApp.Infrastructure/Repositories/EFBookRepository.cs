using Microsoft.EntityFrameworkCore;
using StoreApp.Entities;
using StoreApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Infrastructure.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private readonly BookDbContext _db;

        public EFBookRepository(BookDbContext db)
        {
            _db = db;
        }

        public IList<Book> GetAll()
        {
            return _db.Books.AsNoTracking().ToList();
        }

        public Book? GetById(int id)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            return book;
        }
        public void Create(Book entity)
        {
            _db.Books.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Book entity)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == entity.Id);
            _db.Books.Remove(book);
            _db.SaveChanges();
        }

        public void Update(int id, Book entity)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            book.Title = entity.Title; book.Price = entity.Price;
            _db.Books.Update(book);
            _db.SaveChanges();
        }
    }
}
