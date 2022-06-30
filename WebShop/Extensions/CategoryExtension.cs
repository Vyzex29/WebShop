using DataAccess.Context.Entity;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class CategoryExtension
    {
        public static CategoryModel ToModel(this Category category)
        {
            var categoryModel = new CategoryModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryModel;
        }
    }
}
