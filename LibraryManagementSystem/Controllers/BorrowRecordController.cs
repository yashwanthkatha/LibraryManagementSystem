using LibraryManagementSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowRecordController : ControllerBase
    {
        private readonly IBorrowRecord _borrowRecordRepository;

        public BorrowRecordController(IBorrowRecord borrowRecordRepository)
        {
            _borrowRecordRepository = borrowRecordRepository;
        }

        [HttpGet("by-date-range")]
        public async Task<IActionResult> GetBorrowRecordsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var borrowRecords = await _borrowRecordRepository.GetBorrowRecordsByDateRange(startDate, endDate);
            if (borrowRecords == null || !borrowRecords.Any())
            {
                return NotFound("No records found");
            }
            return Ok(borrowRecords);
        }

        [HttpGet("highest-fine")]
        public async Task<IActionResult> GetBorrowRecordWithHighestFine()
        {
            var borrowRecord = await _borrowRecordRepository.GetBorrowRecordWithHighestFine();
            if (borrowRecord == null)
            {
                return NotFound("No records found");
            }
            return Ok(borrowRecord);
        }

        [HttpGet("longest-borrow-duration")]
        public async Task<IActionResult> GetLongestBorrowDuration()
        {
            var borrowRecord = await _borrowRecordRepository.GetLongestBorrowDuration();
            if (borrowRecord == null)
            {
                return NotFound("No records found");
            }
            return Ok(borrowRecord);
        }
    }
}
