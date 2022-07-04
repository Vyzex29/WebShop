using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class SubCategoryModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public CategoryModel Category { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
