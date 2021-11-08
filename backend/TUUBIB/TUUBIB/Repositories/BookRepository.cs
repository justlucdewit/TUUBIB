using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TUUBIB.Models;

namespace TUUBIB.Repositories
{
    public class BookRepository
    {
        private readonly DatabaseContext _context;

        public BookRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task CreateBook(Book book)
        {
            // Save the book to the database
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateBook(Book book)
        {
            var dbBook = await _context.Books.FirstOrDefaultAsync(_dbBook => _dbBook.Id == book.Id);
            dbBook.Genres = book.Genres;
            dbBook.Title = book.Title;
            dbBook.AuthorName = book.AuthorName;
            dbBook.CoverBase64 = book.CoverBase64;
            dbBook.PageCount = book.PageCount;

            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBook(int bookId) =>
            await _context.Books.Where(book => book.Id == bookId).FirstOrDefaultAsync();

        public async Task<List<Book>> GetAllBooks() =>
            await _context.Books.ToListAsync();

        public async Task DeleteBook(int bookId)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == bookId);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}