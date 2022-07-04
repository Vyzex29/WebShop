using DataAccess.Context.Entity;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class SubCategoryExtension
    {
        public static SubCategoryModel ToModel(this SubCategory subCategory)
        {
            List<ProductModel> productModels = new List<ProductModel>();
            foreach(var product in subCategory.Products)
            {
                productModels.Add(new ProductModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                });
            }
            var categoryModel = new SubCategoryModel
            {
                Id = subCategory.Id,
                Name = subCategory.Name,
                Category = new CategoryModel
                {
                    Id = subCategory.Category.Id,
                    Name = subCategory.Category.Name
                },
                Products = productModels
            };

            return categoryModel;
        }
    }
}
