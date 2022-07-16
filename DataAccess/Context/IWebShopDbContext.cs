using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Context
{
    public interface IWebShopDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public int SaveChanges();
    }
}
