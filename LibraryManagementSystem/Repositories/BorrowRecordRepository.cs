using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BorrowRecordRepository: IBorrowRecord
    {
        private readonly LibraryContext _context;

        public BorrowRecordRepository(LibraryContext context)
        {
            _context = context;
        }       

        public async Task<IEnumerable<BorrowRecord>> GetBorrowRecordsByDateRange(DateTime startDate, DateTime endDate)
        {
            var borrowRecordsByDateRange = await _context.BorrowRecords
                .Where(br => br.BorrowDate >= startDate && br.BorrowDate <= endDate)
                .ToListAsync();

            return borrowRecordsByDateRange;
        }

        public async Task<BorrowRecord> GetBorrowRecordWithHighestFine()
        {
            var borrowRecordWithHighestFine = await _context.BorrowRecords
                .OrderByDescending(br => br.FineAmount)
                .FirstOrDefaultAsync();

            return borrowRecordWithHighestFine;
        }

        public async Task<BorrowRecord> GetLongestBorrowDuration()
        {
            // Fetch all borrow records
            var borrowRecords = await _context.BorrowRecords
                .ToListAsync();            

            var longestBorrowDuration =  borrowRecords
                .Select(br => new
                {
                    BorrowRecord = br,
                    Duration = (br.ReturnDate - br.BorrowDate).TotalDays
                })
                .OrderByDescending(br => br.Duration)
                .Select(br => br.BorrowRecord)
                .FirstOrDefault();

            return longestBorrowDuration;
        }
    }
}
