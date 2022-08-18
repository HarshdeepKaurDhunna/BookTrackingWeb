
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace BookTrackingWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BookTrackingWebContext _context;
        private Book book { get; set; }

        public int totalBooks = 0;
        public int wantReadBooks = 0;
        public int currentlyReadBooks = 0;
        public int readBooks = 0;
        public string[] Labels { get; set; }
        public string Legend { get; set; }
        public int[] Data { get; set; }
        public IList<BookReadTrack> BookTrackList { get; set; }
        public IndexModel(BookTrackingWebContext context)
        {
            _context = context;
        }
       
        public void OnGet()
        {
            List<Book> BooksList = _context.Books.ToList();
            List<BookReadTrack> BookTrackList = _context.BookReadTracks.Include(b => b.Book).ToList();
                         
            totalBooks = BooksList.Count;
            wantReadBooks = BooksList.Count(x => x.BookStatus == "1");
            currentlyReadBooks = BooksList.Count(x => x.BookStatus == "2");
            readBooks = BooksList.Count(x => x.BookStatus == "3");
        }
    }
}
