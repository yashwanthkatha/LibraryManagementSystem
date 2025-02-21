using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBook
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBook(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook != null) return false;
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBookRating(int id, decimal rating)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null) return false;

            existingBook.Rating = rating;                     
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Book> GetBookWithMostRecentBorrow()
        {
            return await _context.Books
                .Select(b => new
                {
                    Book = b,
                    MostRecentBorrowDate = b.BorrowRecords
                        .OrderByDescending(br => br.BorrowDate)
                        .Select(br => br.BorrowDate)
                        .FirstOrDefault()
                })
                .OrderByDescending(b => b.MostRecentBorrowDate)
                .Select(b => b.Book)
                .FirstOrDefaultAsync();
        }
    }
}
