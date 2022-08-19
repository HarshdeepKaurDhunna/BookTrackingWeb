using System;
using System.Collections.Generic;
using System.Linq;
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using BookTrackingWebLibrary.Models;
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

        [HttpGet("bookTrack")]
        public ActionResult fetchBookTrack(int bookId)
        {
            try
            {
                List<BookReadTrack> bookReadTracks = _db.BookReadTracks.Where(track => track.BookId == bookId).OrderByDescending(track => track.BookReadDate).ToList();
                return Ok(bookReadTracks);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Could not find the requested book read track");
            }
        }

        [HttpGet("bookTracks")]
        public ActionResult fetchBookTracks()
        {
            List<BookReadTrack> bookReadTracks = new List<BookReadTrack>();

            bookReadTracks = _db.BookReadTracks.ToList();

            return Ok(bookReadTracks);
        }


        [HttpGet("BookTrackSummary")]
        public ActionResult getBookTrackSummary()
        {
            try
            {
                List<Book> Books = _db.Books.ToList();

                BookTrackSummary bookTrackSummary = new BookTrackSummary();

                foreach (Book book in Books)
                {
                    BookReadTrack trackingForBook = _db.BookReadTracks.Where(track => track.BookId == book.BookId).OrderByDescending(track => track.BookReadDate).Single();
                    bookTrackSummary.BookId = book.BookId;
                    bookTrackSummary.BookISBN = book.BookISBN;
                    bookTrackSummary.BookTitle = book.BookTitle;
                    bookTrackSummary.LastReadOn = trackingForBook.BookReadDate;
                    bookTrackSummary.TotalPages = trackingForBook.BookTotalPagesRead;
                    bookTrackSummary.RemainingPages = trackingForBook.BookTotalPagesRead - trackingForBook.BookToPage;
                }
                return Ok(bookTrackSummary);
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Could not find the requested book track summary");
            }
        }
    }
}
