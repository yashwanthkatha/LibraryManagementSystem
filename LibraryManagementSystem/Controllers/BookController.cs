using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook _bookRepository;

        public BookController(IBook bookRepository)
        {
            _bookRepository = bookRepository;
        }

       
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var result = await _bookRepository.AddBook(book);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
        
        [HttpPut("UpdateRating/{id}/{rating}")]
        public async Task<IActionResult> UpdateBookRating(int id, decimal rating)
        {
            var result = await _bookRepository.UpdateBookRating(id, rating);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
       
        [HttpDelete("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookRepository.DeleteBook(id);

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }
       
        [HttpGet("most-recent-borrow")]
        public async Task<IActionResult> GetBookWithMostRecentBorrow()
        {
            var book = await _bookRepository.GetBookWithMostRecentBorrow();

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound("No records found");
        }
    }
}

