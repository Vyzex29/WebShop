using DataAccess.Context.Entity;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class ProductExtension
    {
        public static ProductModel ToModel(this Product productFromDb)
        {
            var productModel = new ProductModel
            {
                Id = productFromDb.Id,
                Name = productFromDb.Name,
                Description = productFromDb.Description,
                Price = productFromDb.Price
            };

            return productModel;
        }
    }
}
