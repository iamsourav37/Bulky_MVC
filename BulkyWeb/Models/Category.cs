using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Length of the Category Name must be between 3 to 50 character long.", MinimumLength = 3)]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

    }
}
