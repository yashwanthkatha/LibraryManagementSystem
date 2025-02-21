using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;


namespace LibraryManagementSystem
{
    [Route("api/[controller]")] 
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly LibraryContext _context; 

        public TestController(LibraryContext context)
        {
            _context = context;  
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public ActionResult<List<Book>> GetAllBooks()     
        {
            return _context.Books.ToList();    
        }        
    }
}
