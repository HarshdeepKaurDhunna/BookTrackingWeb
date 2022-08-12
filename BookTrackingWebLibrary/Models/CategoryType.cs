using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookTrackingWebLibrary
{
    public class CategoryType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryTypeId { get; set; } // Id for Category Type
        [Required]
        public string CategoryTypeName { get; set; } // Category Type name

        //public List<Category> Categories { get; set; } //List of Categories referenced by foreign key
    }
}
