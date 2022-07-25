using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public interface IProductManager
    {
        List<Product> GetSpecificProducts(int subCategoryId);
    }
}