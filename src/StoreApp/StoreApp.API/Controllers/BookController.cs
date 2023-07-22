using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApp.API.Models;
using StoreApp.API.Repositories;

namespace StoreApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext _db;

        public BookController(BookDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _db.Books.ToList();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
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
            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok(book);
        }
        [HttpDelete("[action]")]
        public IActionResult DeleteBook(int id)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound("Girdiğiniz ID'ye ait bir değer bulunamadı");
            }
            _db.Books.Remove(book);
            _db.SaveChanges();
            return Ok(book);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateBook(int id, Book _book)
        {
            var book = _db.Books.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound("Verilen ID'ye ait güncellenecek değer bulunamadı");
            }
            book.Title = _book.Title;
            book.Price = _book.Price;
            _db.SaveChanges();
            return Ok(book);
        }
    }
}
