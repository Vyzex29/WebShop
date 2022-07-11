using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public interface ICartManager
    {
        public bool CheckWhetherUserHasCart(int UserId);

        public Cart? GetUserCart(int UserId);

        public void CreateCart(Cart cart);

        public void AddItemToCart(int userId, int productId);

        public void RemoveItemFromCart(int userId, int productId);

        public void Purchase(int userId);
    }
}
