using System;
using System.Collections.Generic;
using System.Linq;
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookTrackingWebAPI.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;

        private readonly BookTrackingWebContext _db;


        public BookController(ILogger<BookController> logger, BookTrackingWebContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost("book")]
        public ActionResult saveBook([FromBody] Book book)
        {
            try
            {
                if (book.BookISBN != null && book.BookISBN != "")
                {
                    _db.Add(book);
                    _db.SaveChangesAsync();
                    return Ok(book);
                }
                else
                {
                    return BadRequest("Invalid input data in the request");
                }
            }
            catch
            {
                return BadRequest("Invalid input data in the request");
            }
        }

        [HttpGet("books")]
        public ActionResult fetchBooks()
        {
            List<Book> Books = new List<Book>();

            Books = _db.Books.ToList();

            return Ok(Books);
        }

        [HttpGet("Book")]
        public ActionResult fetchBook(int id)
        {
            try
            {
                Book book = _db.Books.Single(book => book.BookId == id);
                return Ok(book);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Could not find the requested book");
            }
        }

        [HttpDelete("book")]
        public ActionResult deleteBook(int id)
        {
            try
            {
                Book book = _db.Books.Single(book => book.BookId == id);

                if (book != null)
                {
                    _db.Remove(book);
                    _db.SaveChangesAsync();
                }
                return Ok("Deleted successfully");
            }
            catch (InvalidOperationException)
            {

                return BadRequest("Could not find the book to delete");
            }

        }


        [HttpPut("book")]
        public ActionResult updateBook([FromBody] Book update)
        {
            try
            {
                Book existing = _db.Books.Single(a => a.BookId == update.BookId);

                if (existing != null)
                {
                    existing.BookISBN = update.BookISBN;
                    existing.BookAuthor = update.BookAuthor;
                    existing.BookAddedDate = update.BookAddedDate;
                    existing.BookStatus = update.BookStatus;
                    existing.BookTitle = update.BookTitle;
                    _db.Update(existing);
                    _db.SaveChangesAsync();
                }
                return Ok(existing);
            }
            catch (InvalidOperationException)
            {

                return BadRequest("Could not find the book to update");
            }
        }

    }
}