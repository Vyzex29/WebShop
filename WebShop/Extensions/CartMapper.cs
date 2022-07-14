using DataAccess.Context.Entity;
using WebShop.Models;

namespace WebShop.Extensions
{
    public class CartMapper
    {
        public  CartModel ToModel(Cart cart)
        {
            List<CartItemModel> cartItems = new List<CartItemModel>();
            CartModel cartModel = new CartModel
            {
                Id = cart.Id,
                CartItems = cartItems
            };

            return cartModel;
        }
    }
}
