using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        //private IList<Book> listBooks;
        public BookController()
        {
            //listBooks = new List<Book>() 
            //{
            //    new Book() { Id = 1, Title = "Suç ve Ceza", Price = 100},
            //    new Book() { Id = 2, Title = "Sefiller", Price = 90},
            //    new Book() { Id = 3, Title = "Romeo ve Juliet", Price = 105}
            //};
        }

        [HttpGet]
        public IActionResult GetAllBook ()
        {
            var books = BookDbContext.listBooks.ToList();
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBookById (int id)
        {
            var book = BookDbContext.listBooks.FirstOrDefault(b => b.Id == id);
            if(book != null)
            {
                return Ok(book);
            }
            return BadRequest("Geçersiz ID değeri girdiniz");
        }
        [HttpPost("[action]")]
        public IActionResult CreateBook (Book _book) 
        {
            var book = _book; 
            if(book.Title == "" || book.Title == "string")
            {
                return BadRequest("Title'a Değer Girilmelidir");
            }
            BookDbContext.listBooks.Add(book);
            return Ok(book);
        }
        [HttpPut("[action]")]
        public IActionResult UpdateBook (int id,Book _book) 
        {
            var book = BookDbContext.listBooks.FirstOrDefault(b=> b.Id == id);
            if(book == null)
            {
                return NotFound("Obje Bulunamadı");
            }
            book.Title = _book.Title;
            book.Price = _book.Price;
            return Ok(book);

        }
        [HttpDelete("[action]")]
        public IActionResult DeleteBook (int id)
        {
            var book = BookDbContext.listBooks.FirstOrDefault(b => b.Id == id);
            if(book == null)
            {
                return NotFound("Girdiğiniz Id'ye Ait Kitap Bulunamadı");
            }
            BookDbContext.listBooks.RemoveAt(id-1);
            return Ok(book);

        }

        //[HttpPut("{id:int}")]
        //public IActionResult UpdateBook2([FromRoute(Name ="id")] int id, [FromBody] Book _book)
        //{
        //    var book = BookDbContext.listBooks.FirstOrDefault(b => b.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound("Obje Bulunamadı");
        //    }
        //    book.Title = _book.Title;
        //    book.Price = _book.Price;
        //    return Ok(book);

        //}

        //[HttpDelete("{id:int}")]
        //public IActionResult DeleteBook2([FromRoute(Name ="id")] int id)
        //{
        //    var book = BookDbContext.listBooks.FirstOrDefault(b => b.Id == id);
        //    if (book == null)
        //    {
        //        return NotFound("Girdiğiniz Id'ye Ait Kitap Bulunamadı");
        //    }
        //    BookDbContext.listBooks.RemoveAt(id - 1);
        //    return Ok(book);

        //}

    }
}
