using DataAccess.Context.Entity;
using System.Buffers.Text;
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
                Price = productFromDb.Price,
                FileName = productFromDb.ImageName,
                Blob = Convert.ToBase64String(productFromDb.Image)

            };

            return productModel;
        }
    }
}
