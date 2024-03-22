using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Length of the Category Name must be between 3 to 50 character long.", MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required(ErrorMessage ="Display Order value is required.")]
        [Range(1, 100)]
        public int DisplayOrder { get; set; }

    }
}
