namespace WebShop.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }

        public string? FileName { get; set; }

        public SubCategoryModel SubCategory { get; set; }
    }
}
