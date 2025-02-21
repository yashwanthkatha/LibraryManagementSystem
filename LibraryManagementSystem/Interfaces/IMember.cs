using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IMember
    {
        Task<IEnumerable<Member>> GetMembersWhoBorrowedBook(int bookId);
        Task<Member> GetMemberWithMostBorrowedBooks();
        Task<IEnumerable<Member>> GetMembersWithMostFrequentBorrowing(DateTime startDate, DateTime endDate);
    }
}
