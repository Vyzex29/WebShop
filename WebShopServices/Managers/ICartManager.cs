using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public interface ICartManager
    {
        public bool CheckWhetherUserHasCart(int UserId);

        public Cart? GetUserCart(int UserId);

        public void CreateCart(Cart cart); 
    }
}
