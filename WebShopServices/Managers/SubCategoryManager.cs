using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace WebShopServices.Managers
{
    public class SubCategoryManager : ISubCategoryManager
    {
        private readonly WebShopDbContext _context;

        public SubCategoryManager(WebShopDbContext context)
        {
            _context = context;
        }

        public void Add(SubCategory subCategory)
        {
            _context.SubCategories.Add(subCategory);
            _context.SaveChanges();
        }

        public List<SubCategory> GetAll()
        {
            return _context.SubCategories
                .Include(sc=> sc.Products)
                .Include(sc => sc.Category)
                .ToList();
        }
    }
}
