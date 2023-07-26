using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.DTO.Requests;
using StoreApp.Entities;
using StoreApp.Infrastructure.Data;
using StoreApp.Services;

namespace StoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILoggerService logger;

        public BookController(IBookService bookService, ILoggerService logger = null)
        {
            this._bookService = bookService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound("Bu ID bulunamadı");
            }
            return Ok(book);
        }
        [HttpPost("[action]")]
        public IActionResult CreateBook(CreateBookRequest _book)
        {
            var book = _book;
            if (book.Title == null || book.Title == "string")
            {
                return BadRequest("Title'a değer girilmelidir");
            }
            _bookService.Create(book);
            return Ok(book);
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteBook(int id)
        {
            var book = _bookService.GetBookForDelete(id);
            if (book == null)
            {
                string message = "Girdiğiniz ID'ye ait bir kitap bulunamadı";
                logger.LogInfo($"{message}");
                return NotFound(message);
            }
            _bookService.Delete(book);
            return Ok(book);
        }
        //[HttpPut("{id:int}")]
        //public IActionResult UpdateBook(int id, Book _book)
        //{
        //    var book = _bookService.GetById(id);
        //    if (book == null)
        //    {
        //        return NotFound("Verilen ID'ye ait güncellenecek değer bulunamadı");
        //    }
        //    _bookService.Update(id, _book);
        //    return Ok(book);
        //}
    }
}
