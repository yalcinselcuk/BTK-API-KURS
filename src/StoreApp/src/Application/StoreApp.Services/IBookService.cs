using StoreApp.DTO.Requests;
using StoreApp.DTO.Responses;
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
        IList<BookResponse> GetAll();
        BookResponse? GetById(int id);

        void Create(CreateBookRequest entity);
        void Update(int id, UpdateBookRequest entity);
        void Delete(DeleteBookRequest entity);
    }
}
