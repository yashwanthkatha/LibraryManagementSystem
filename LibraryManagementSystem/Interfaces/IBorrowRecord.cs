using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IBorrowRecord
    {        
        Task<IEnumerable<BorrowRecord>> GetBorrowRecordsByDateRange(DateTime startDate, DateTime endDate);
        Task<BorrowRecord> GetBorrowRecordWithHighestFine();
        Task<BorrowRecord> GetLongestBorrowDuration();
    }
}
