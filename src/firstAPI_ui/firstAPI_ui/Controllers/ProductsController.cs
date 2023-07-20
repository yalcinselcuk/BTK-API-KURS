using firstAPI_ui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstAPI_ui.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>() 
            {
                new Product() { Id = 1, Name = "Bilgisayar"},
                new Product() { Id = 2, Name = "Tablet"},
                new Product() { Id = 3, Name = "Telefon"}
            };
            return Ok(products);
        }
    }
}
