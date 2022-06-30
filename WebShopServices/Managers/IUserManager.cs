using DataAccess.Context.Entity;

namespace WebShopServices.Managers
{
    public interface IUserManager
    {
        void AddUser(User user);

        User? GetUser(string email, string password);

        bool CheckIfUserEmailExists(string email);
    }
}
