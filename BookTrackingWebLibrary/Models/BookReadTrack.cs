using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookTrackingWebLibrary
{
    public class BookReadTrack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookReadTrackId { get; set; } //book read Id

        [Required]
        [DataType(DataType.Date)]
        public DateTime BookReadDate { get; set; } //Date 

        [Required]
        public int BookTotalPage { get; set; } //field for total pages read

        [Required]
        public int BookFromPage { get; set; } //From n to to calcualte how much user have read

        [Required]
        public int BookToPage { get; set; }

        public int BookId { get; set; } //reference to book id
        public virtual Book Book { get; set; }
    }
}
