using DataAccess.Context;
using DataAccess.Context.Entity;
using Microsoft.EntityFrameworkCore;

namespace WebShopServices.Managers
{
    public class CartManager : ICartManager
    {
        private readonly WebShopDbContext _context;

        public CartManager(WebShopDbContext context)
        {
            _context = context;
        }

        public void AddItemToCart(int userId, int productId)
        {
            Cart cart = GetUserCart(userId);
            if (cart.CartItems.Exists(ci => ci.Product.Id == productId))
            {
                var existingCartItem = cart.CartItems.First(ci => ci.Product.Id == productId);
                existingCartItem.Quantity += 1;
            }
            else
            {
                CartItem item = new();
                var selectedProduct = _context.Products.FirstOrDefault(p => p.Id == productId);
                item.Product = selectedProduct;
                item.Quantity = 1;
                cart.CartItems.Add(item);
            }
            _context.SaveChanges();
        }

        public bool CheckWhetherUserHasCart(int UserId)
        {
            bool userHasCart;

            userHasCart = _context.Carts.Any(cart => (cart.UserId == UserId) && (cart.IsPurchased == false));

            return userHasCart;
        }

        public void CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();

        }

        public void EditQuantity(int userId, int quantity, int productId)
        {
            Cart cart = GetUserCart(userId);
            if (cart.CartItems.Exists(ci => ci.Product.Id == productId))
            {
                var existingCartItem = cart.CartItems.First(ci => ci.Product.Id == productId);
                if (quantity > 0)
                {
                    existingCartItem.Quantity = quantity;
                }
                _context.SaveChanges();
            }
        }

        public Cart? GetUserCart(int UserId)
        {
            return _context.Carts
                .Include(cart=> cart.CartItems)
                .ThenInclude(cartItem => cartItem.Product)
                .FirstOrDefault(cart => (cart.UserId == UserId) && (cart.IsPurchased == false));
        }

        public void Purchase(int userId)
        {
            Cart cart = GetUserCart(userId);
            cart.IsPurchased = true;
            cart.PurchaseDate = DateTime.UtcNow;
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(int userId, int cartItemId)
        {
            Cart cart = GetUserCart(userId);
            var cartItemToRemove = cart.CartItems.FirstOrDefault(ci => ci.Id == cartItemId);
            cart.CartItems.Remove(cartItemToRemove);
            _context.SaveChanges();
        }

        public void SubtractItemFromCart(int userId, int productId)
        {
            Cart cart = GetUserCart(userId);
            if (cart.CartItems.Exists(ci => ci.Product.Id == productId))
            {
                var existingCartItem = cart.CartItems.First(ci => ci.Product.Id == productId);
                if (existingCartItem.Quantity > 1)
                {
                    existingCartItem.Quantity -= 1;
                }
                _context.SaveChanges();
            }
        }
    }
}
