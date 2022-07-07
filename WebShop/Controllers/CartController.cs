using Microsoft.AspNetCore.Mvc;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnItem()
        {
            return View();
        }

        public IActionResult RemoveAnItem()
        {
            return View();
        }

        public IActionResult Purchase()
        {
            return View();
        }

    }
}
