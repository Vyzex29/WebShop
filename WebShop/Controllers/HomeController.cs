using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebShopDbContext _context;

        public HomeController(ILogger<HomeController> logger, WebShopDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? selectedCategory = 1)
        {

            List<CategoryModel> categories = new List<CategoryModel>();
            List<ProductModel> products = new List<ProductModel>();
            using (_context)
            {
                categories = _context.Categories.Select(categoryFromDb => new CategoryModel
                {
                    Id = categoryFromDb.Id,
                    Name = categoryFromDb.Name
                }).ToList();

                if (categories.Exists(c=>c.Id == selectedCategory))
                {
                    products = _context.Products.Where(pr => pr.Subcategory.Id == selectedCategory).Select(productFromDb => new ProductModel
                    {
                        Id = productFromDb.Id,
                        Name = productFromDb.Name,
                        Description = productFromDb.Description,
                        Price = productFromDb.Price
                    }).OrderBy(product => product.Name)
                .ToList();
                }
                
            }

            var homeView = new HomeViewModel
            {
                categories = categories,
                products = products,
            };

            return View(homeView);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}