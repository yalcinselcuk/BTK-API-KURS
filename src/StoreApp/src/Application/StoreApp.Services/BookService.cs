using AutoMapper;
using StoreApp.DTO.Requests;
using StoreApp.DTO.Responses;
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
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper = null)
        {
            this.bookRepository = bookRepository;
            _mapper = mapper;
        }

        public IList<BookResponse> GetAll()
        {
            var books = bookRepository.GetAll();
            var response = _mapper.Map<IList<BookResponse>>(books);
            return response;
        }

        public BookResponse? GetById(int id)
        {
            var book = bookRepository.GetById(id);
            return _mapper.Map<BookResponse>(book);
        }

        public void Create(CreateBookRequest entity)
        {
            var book = _mapper.Map<Book>(entity);
            bookRepository.Create(book);
        }

        public void Delete(DeleteBookRequest entity)
        {
            var book = _mapper.Map<Book>(entity);
            bookRepository.Delete(book);
        }
        public DeleteBookRequest GetBookForDelete(int id)
        {
            var book = bookRepository.GetById(id);
            return _mapper.Map<DeleteBookRequest>(book);
        }

        public void Update(int id, UpdateBookRequest entity)
        {
            var book = _mapper.Map<Book>(entity);
            bookRepository.Update(id, book);
        }

    }
}
