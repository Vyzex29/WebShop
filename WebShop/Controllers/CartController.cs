using DataAccess.Context.Entity;
using Microsoft.AspNetCore.Mvc;
using WebShop.Extensions;
using WebShopServices.Managers;

namespace WebShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager _cartManager;
        private readonly IUserManager _userManager;

        public CartController(ICartManager cartManager, IUserManager userManager)
        {
            _cartManager = cartManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetUserId();
            if (userId is null)
            {
                return RedirectToAction("SignIn", "User");
            }
            var currentCart = _cartManager.GetUserCart((int)userId).ToModel();
            return View(currentCart);
        }

        [HttpPost]
        public IActionResult AddAnItem(int itemId)
        {
            var userId = HttpContext.Session.GetUserId();
            if (userId is null)
            {
                return RedirectToAction("SignIn", "User");
            }
            _cartManager.AddItemToCart((int)HttpContext.Session.GetUserId(), itemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult SubtractAnItem(int itemId)
        {
            _cartManager.SubtractItemFromCart((int)HttpContext.Session.GetUserId(), itemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult RemoveAnItem(int cartItemId)
        {
            _cartManager.RemoveItemFromCart((int)HttpContext.Session.GetUserId(), cartItemId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public JsonResult EditQuantity(int quantity)
        {
            return new JsonResult(Ok());
        }
        public IActionResult Purchase()
        {
            var userId = HttpContext.Session.GetUserId();
            if (userId is null)
            {
                return RedirectToAction("SignIn", "User");
            }
            var purchaseModel = _cartManager.GetUserCart((int)userId).ToPurchaseModel();
            _cartManager.Purchase((int)userId);
            _cartManager.CreateCart(new Cart
            {
                UserId = (int)userId
            });
            return View(purchaseModel);
        }

    }
}
