using LibraryManagementSystem.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMember _memberRepository;

        public MemberController(IMember memberRepository)
        {
            _memberRepository = memberRepository;
        }

        [HttpGet("members-by-book/{bookId}")]
        public async Task<IActionResult> GetMembersWhoBorrowedBook(int bookId)
        {
            var members = await _memberRepository.GetMembersWhoBorrowedBook(bookId);
            if (members == null || !members.Any())
            {
                return NotFound("No records found");
            }
            return Ok(members);
        }

        [HttpGet("most-borrowed-books")]
        public async Task<IActionResult> GetMemberWithMostBorrowedBooks()
        {
            var member = await _memberRepository.GetMemberWithMostBorrowedBooks();
            if (member == null)
            {
                return NotFound("No records found");
            }
            return Ok(member);
        }

        [HttpGet("most-frequent-borrowing")]
        public async Task<IActionResult> GetMembersWithMostFrequentBorrowing([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var members = await _memberRepository.GetMembersWithMostFrequentBorrowing(startDate, endDate);

            if (members == null || !members.Any())
            {
                return NotFound("No records found");
            }

            return Ok(members);
        }
    }
}
