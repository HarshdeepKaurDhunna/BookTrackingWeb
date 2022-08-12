using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookTrackingWebLibrary
{
    public class BookQuote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookQuoteId { get; set; } //quote ID

        [Required]
        public string BookPageNumber { get; set; } //book page number to quote to

        [Required]
        public string BookQuoteDescription { get; set; } //the quote 

        public int BookId { get; set; } //reference to bookID
        public virtual Book Book { get; set; }
    }
}
