using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class MemberRepository: IMember
    {
        private readonly LibraryContext _context;

        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Member>> GetMembersWhoBorrowedBook(int bookId)
        {
            var membersWhoBorrowedBook = await _context.BorrowRecords
                .Where(br => br.BookId == bookId)
                .Select(br => br.Member)
                .Distinct()
                .ToListAsync();

            return membersWhoBorrowedBook;
        }        

        public async Task<Member> GetMemberWithMostBorrowedBooks()
        {
            var memberWithMostBorrowedBooks = await _context.Members
                .Select(m => new
                {
                    Member = m,
                    BorrowCount = m.BorrowRecords.Count
                })
                .OrderByDescending(m => m.BorrowCount)
                .Select(m => m.Member)
                .FirstOrDefaultAsync();

            return memberWithMostBorrowedBooks;
        }

        public async Task<IEnumerable<Member>> GetMembersWithMostFrequentBorrowing(DateTime startDate, DateTime endDate)
        {
            // Retrieve all members with their borrow record counts within the specified date range
            var membersWithBorrowCounts = await _context.Members
                .Select(m => new
                {
                    Member = m,
                    BorrowCount = _context.BorrowRecords
                        .Count(br => br.MemberId == m.Id && br.BorrowDate >= startDate && br.BorrowDate <= endDate)
                })
                .ToListAsync();

            // Filter members with at least one borrow record within the date range and order by borrow count descending
            var result = membersWithBorrowCounts
                .Where(m => m.BorrowCount > 0)
                .OrderByDescending(m => m.BorrowCount)
                .Select(m => m.Member);

            return result;
        }
    }
}

