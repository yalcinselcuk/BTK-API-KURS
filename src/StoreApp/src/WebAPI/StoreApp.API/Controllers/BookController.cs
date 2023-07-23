using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
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
        public IActionResult CreateBook(Book _book)
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
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound("Girdiğiniz ID'ye ait bir değer bulunamadı");
            }
            _bookService.Delete(book);
            return Ok(book);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateBook(int id, Book _book)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound("Verilen ID'ye ait güncellenecek değer bulunamadı");
            }
            _bookService.Update(id, _book);
            return Ok(book);
        }
    }
}
