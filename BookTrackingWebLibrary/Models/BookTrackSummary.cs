using System;
namespace BookTrackingWebLibrary.Models
{
    public class BookTrackSummary
    {
        public int BookId { get; set; } //Id for books

        public string BookISBN { get; set; } //ISBN of book

        public string BookTitle { get; set; } //Book title 

        public int TotalPages { get; set; } // Book Total Pages

        public DateTime LastReadOn { get; set; } // last read date

        public int RemainingPages { get; set; }// remaining pages to read
    }
}
