using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IBook
    {
        Task<bool> AddBook(Book book);
        Task<bool> UpdateBookRating(int id, decimal rating); 
        Task<bool> DeleteBook(int id);
        Task<Book> GetBookWithMostRecentBorrow();
    }
}
