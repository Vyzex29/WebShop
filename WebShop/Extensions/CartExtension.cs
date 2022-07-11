using DataAccess.Context.Entity;
using WebShop.Models;

namespace WebShop.Extensions
{
    public static class CartExtension
    {
        public static CartModel ToModel(this Cart cart)
        {
            List<CartItemModel> cartItems = MappingCartItems(cart);
            CartModel cartModel = new CartModel
            {
                Id = cart.Id,
                CartItems = cartItems
            };

            return cartModel;
        }

        public static PurchaseModel ToPurchaseModel(this Cart cart)
        {
            List<CartItemModel> cartItems = MappingCartItems(cart);
            int sum = 0;

            foreach (CartItemModel item in cartItems)
            {
                sum += item.Product.Price * item.Quantity; 
            }

            PurchaseModel purchaseModel = new PurchaseModel
            {
                CartItems = cartItems,
                TotalPrice = sum
            };

            return purchaseModel;
        }

        private static List<CartItemModel> MappingCartItems(Cart cart)
        {
            var cartItems = new List<CartItemModel>();
            foreach (var item in cart.CartItems)
            {
                cartItems.Add(new CartItemModel
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = new ProductModel
                    {
                        Id = item.Product.Id,
                        Name = item.Product.Name,
                        Description = item.Product.Description,
                        FileName = item.Product.ImageName,
                        Price = item.Product.Price
                    }
                });
            }

            return cartItems;
        }
    }
}
