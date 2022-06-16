using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public List<ProductModel> Products { get; set; }
    }
}
