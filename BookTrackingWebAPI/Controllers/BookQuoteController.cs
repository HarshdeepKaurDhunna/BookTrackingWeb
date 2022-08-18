using System;
using System.Collections.Generic;
using System.Linq;
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookTrackingWebAPI.Controllers
{
    public class BookQuoteController : Controller
    {
        private readonly ILogger<BookQuoteController> _logger;

        private readonly BookTrackingWebContext _db;


        public BookQuoteController(ILogger<CategoryController> logger, BookTrackingWebContext db)
        {
            _logger = (ILogger<BookQuoteController>)logger;
            _db = db;
        }

        [HttpPost("bookQuote")]
        public ActionResult savebookQuote(int bookId, string bookPageNumber, string bookQuoteDescription)
        {
            try
            {
                if (bookId > 0 || bookPageNumber != null || bookQuoteDescription != null)
                {
                    BookQuote bookQuote = new BookQuote();
                    bookQuote.BookId = bookId;
                    bookQuote.BookPageNumber = bookPageNumber;
                    bookQuote.BookQuoteDescription = bookQuoteDescription;

                    _db.Add(bookQuote);
                    _db.SaveChangesAsync();
                    return Ok(bookQuote);
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

        [HttpGet("bookQuote")]
        public ActionResult fetchBookQuotes(int bookId)
        {
            try
            {
                List<BookQuote> bookQuote = _db.BookQuotes.Where(track => track.BookId == bookId).ToList();
                return Ok(bookQuote);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Could not find the requested book quote");
            }
        }

        [HttpGet("bookQuote")]
        public ActionResult fetchBookQuotes()
        {
            List<BookQuote> bookQuotes = new List<BookQuote>();

            bookQuotes = _db.BookQuotes.ToList();

            return Ok(bookQuotes);
        }
    }
}
