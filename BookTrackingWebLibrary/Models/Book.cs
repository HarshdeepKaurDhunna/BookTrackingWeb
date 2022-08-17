using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookTrackingWebLibrary
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; } //Id for books
        [Required]
        public string BookISBN { get; set; } //ISBN of book 

        [Required]
        public string BookTitle { get; set; } //Book title 

        [Required]
        public string BookAuthor { get; set; } //Book author

        public string BookStatus { get; set; } //Book status, if done reading or going to read or is currently reading

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookAddedDate { get; set; } //Date that the book was added 

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public override string ToString()
        {
            return string.Format("BookISBN: {0}, BookTitle: {1}, BookAuthor: {2}, BookStatus: {3}, BookAddedDate: {4}, CategoryId: {5}", BookISBN, BookTitle, BookAuthor, BookStatus, BookAddedDate, CategoryId);
        }
    }
}
