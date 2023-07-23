using StoreApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Services
{
    public interface IBookService
    {
        IList<Book> GetAll();
        Book? GetById(int id);

        void Create(Book entity);
        void Update(int id, Book entity);
        void Delete(Book entity);
    }
}
