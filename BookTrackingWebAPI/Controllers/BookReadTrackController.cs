using System;
using System.Collections.Generic;
using System.Linq;
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookTrackingWebAPI.Controllers
{
    public class BookReadTrackController: Controller
    {
        private readonly ILogger<BookReadTrackController> _logger;

        private readonly BookTrackingWebContext _db;


        public BookReadTrackController(ILogger<BookReadTrackController> logger, BookTrackingWebContext db)
        {
            _logger = (ILogger<BookReadTrackController>)logger;
            _db = db;
        }

        [HttpPost("bookTrack")]
        public ActionResult saveBookTrackingDetails(int bookId, int totalPagesRead)
        {
            try
            {
                if (bookId > 0 || totalPagesRead > 0)
                {
                    BookReadTrack bookReadTrack = new BookReadTrack();
                    bookReadTrack.BookId = bookId;
                    bookReadTrack.BookReadDate = DateTime.Now;

                    BookReadTrack lastTrackingEntryForBook = _db.BookReadTracks.Where(track => track.BookId == bookId).OrderByDescending(track => track.BookReadDate).First();

                    bookReadTrack.BookTotalPagesRead = totalPagesRead;

                    bookReadTrack.BookFromPage = lastTrackingEntryForBook.BookToPage;
                    bookReadTrack.BookToPage = lastTrackingEntryForBook.BookToPage + totalPagesRead;

                    _db.Add(bookReadTrack);
                    _db.SaveChangesAsync();
                    return Ok(bookReadTrack);
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
    }
}
