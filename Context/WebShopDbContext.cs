using Microsoft.EntityFrameworkCore;
using WebShop.Context.Entity;

namespace WebShop.Context
{
    public class WebShopDbContext : DbContext
    {

        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base (options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
