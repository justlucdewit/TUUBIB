using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TUUBIB.Models;
using TUUBIB.Repositories;

namespace TUUBIB.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;
        
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost("books")]
        public async Task<ActionResult> CreateBook([FromBody] Book book)
        {
            // Create the book
            await _bookRepository.CreateBook(book);

            return Ok();
        }
        
        [HttpGet("books")]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            // Get a list of all books in the database
            var books = await _bookRepository.GetAllBooks();

            return Ok(books);
        }
        
        [HttpGet("books/{bookId:int}")]
        public async Task<ActionResult<Book>> GetBook(int bookId)
        {
            // Get the book from the book id
            var book = await _bookRepository.GetBook(bookId);
            
            return Ok(book);
        }
        
        [HttpPatch("books")]
        public async Task<ActionResult> UpdateBook([FromBody] Book book)
        {
            // Update the book in the database
            await _bookRepository.UpdateBook(book);

            return Ok();
        }

        [HttpDelete("books/{bookId:int}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            // Delete the book from the database based on the book id
            await _bookRepository.DeleteBook(bookId);

            return Ok();
        }
    }
}