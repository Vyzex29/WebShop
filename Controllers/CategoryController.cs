using Microsoft.AspNetCore.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class CategoryController : Controller
    {
        //adress.com/Category
        public IActionResult Index()
        {
            return View(Database.categoryModels);
        }


        // adress.com/Category/View/{id} --> FIND ALL PRODUCTS UNDER A SPECIFIC CATEGORY
        public IActionResult View(int id)
        {
            var productsInSelectedCategory = Database.productModels
                .Where(product => product.category.Id == id).ToList();
            string categoryName = Database.categoryModels.FirstOrDefault(c => c.Id == id).Name;
            var productViewModel = new ProductViewModel
            {
                CategoryName = categoryName,
                Products = productsInSelectedCategory
            };

            return View(productViewModel);
        }
    }
}
