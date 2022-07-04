using DataAccess.Context.Entity;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class CreateSubCategoryModel
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "A category must be selected!")]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}
