using DataAccess.Context.Entity;
using System.ComponentModel.DataAnnotations;
namespace WebShop.Models
{
    public class CreateProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public List<Category> Categories { get; set; }
    }
}
