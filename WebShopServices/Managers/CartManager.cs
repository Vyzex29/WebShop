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

        public Cart? GetUserCart(int UserId)
        {
            return _context.Carts
                .Include(cart=> cart.CartItems)
                .ThenInclude(cartItem => cartItem.Product)
                .FirstOrDefault(cart => (cart.UserId == UserId) && (cart.IsPurchased == false));
        }
    }
}
