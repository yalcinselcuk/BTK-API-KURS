using firstAPI_ui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace firstAPI_ui.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        
 
        [HttpGet]

        public IActionResult GetMessage()
        {
            var result =  new ResponseModel() 
            {
                HttpStatus = 200, 
                Message="Başarılı"
            };
            return Ok(result);
        }
    }
}
