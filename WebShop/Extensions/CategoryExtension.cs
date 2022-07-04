using DataAccess.Context.Entity;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class CategoryExtension
    {
        public static CategoryModel ToModel(this Category category)
        {
            var subCategories = new List<SubCategoryModel>();

            foreach (var subCategory in category.SubCategories)
            {
                subCategories.Add(new SubCategoryModel
                {
                    Id = subCategory.Id,
                    Name = subCategory.Name,

                });
            }
            var categoryModel = new CategoryModel
            {
                Id = category.Id,
                Name = category.Name,
                SubCategories = subCategories
            };

            return categoryModel;
        }
    }
}
