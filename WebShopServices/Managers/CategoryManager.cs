using DataAccess.Context;
using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public class CategoryManager : ICategoryManager
    {
        private readonly WebShopDbContext _context;

        public CategoryManager(WebShopDbContext context)
        {
            _context = context;

        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
