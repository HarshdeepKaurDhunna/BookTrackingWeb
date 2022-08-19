
using BookTrackingWebData.Data;
using BookTrackingWebLibrary;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
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
        public string[] Labels;
        public int[] Data;
        public IList<BookReadTrack> BookTrackList { get; set; }
        public IndexModel(BookTrackingWebContext context)
        {
            _context = context;
        }
       
        /**
         * @Method popukate data on page load
         */
        public void OnGet()
        {
           
            //BookReadTrack list from Db 
            List<BookReadTrack> BookTrackList = _context.BookReadTracks.Include(b => b.Book).ToList();

            //Filter BookTrackList to get bookreadDate and pageCount for chart.js according to status
            List<string> LabelList = BookTrackList.Select(item => convertDateToString(item.BookReadDate)).ToList();
            List<int> DataList = BookTrackList.Select(item => getBookPages(item.BookToPage, item.BookFromPage)).ToList();

            //Convert List to array to populate in chart
            Labels = LabelList.ToArray();
            Data = DataList.ToArray();

            //book list from Db 
            List<Book> BooksList = _context.Books.ToList();

            //Filter BooksList to get count of books according to status
            totalBooks = BooksList.Count;
            wantReadBooks = BooksList.Count(x => x.BookStatus == "1");
            currentlyReadBooks = BooksList.Count(x => x.BookStatus == "2");
            readBooks = BooksList.Count(x => x.BookStatus == "3");
        }

        //Method to get page count
        public int getBookPages(int endPage, int startPage)
        {
            return endPage - startPage;
        }

        //Method to format date
        public string convertDateToString(DateTime dateVal)
        {
            return dateVal.ToString("MMMM dd, yyyy"); ; ;
        }
    }
}
