using DataAccess.Context;
using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public class ProductManager : IProductManager
    {
        private readonly WebShopDbContext _context;

        public ProductManager(WebShopDbContext context)
        {
            _context = context;

        }

        public List<Product> GetSpecificProducts(int subCategoryId)
        {
            var products = _context.Products
                     .Where(pr => pr.Subcategory.Id == subCategoryId)
                     .OrderBy(product => product.Name).ToList();

            return products;

        }
    }
}
