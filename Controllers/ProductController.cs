using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var productsSortedByName = Database.productModels.OrderBy(x => x.Name).ToList();
            return View(productsSortedByName);
        }

        public IActionResult View(int id)
        {
            var selectedProduct = Database.productModels.FirstOrDefault(x => x.Id == id);
            if (selectedProduct == null){
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(selectedProduct);
            }
            
        }
    }
}
