using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace BookTrackingWebLibrary
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; } //id for cateogry

        [Required]
        public string CategoryName { get; set; } //name for category

        [Required]
        public int CategoryTypeId { get; set; } //foreign key connecting Category Type

        
        public CategoryType CategoryType { get; set; } //foreign key connecting Category Type

        [JsonIgnore]
        public List<Book> Books { get; private set; } //added reference for books 
    }
}
