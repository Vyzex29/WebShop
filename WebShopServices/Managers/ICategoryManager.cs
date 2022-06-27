
using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public interface ICategoryManager
    {
        public List<Category> GetAll();

        public void Add(Category category);
    }
}
