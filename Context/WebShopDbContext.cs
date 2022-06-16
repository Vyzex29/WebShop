using Microsoft.EntityFrameworkCore;
using WebShop.Context.Entity;

namespace WebShop.Context
{
    public class WebShopDbContext : DbContext
    {
        /*
         * 1. Get the 3 EntityFrameworkCore packages from nuget
         * 2. Create Entities (classes that will be used to create the tables in db)
         * 3. Create DBCONTEXT and write the DBSets for the created entities
         * 4. Inside program add the builder.Services.AddDbContext
         * 5. Don't forget about the ConnectionStrings in AppSettings 
         * 6. Add-Migration  (add-migration "Type name of migration")in package manager console -- success if created the Migrations folder with migrations
         * 7. update-database in package manager console
         * 8. To use the dbContext don't forget to add it to the controller as a property and initialize it
         * through the constuctor, the context is then injected by the builder:
         *                          private readonly WebShopDbContext _context;
                                    public CategoryController(WebShopDbContext context)
                                    {
                                        _context = context;
                                    }
            9. Use the context to access the database or update the database
         */
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options) : base (options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
